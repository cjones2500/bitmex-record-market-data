import pandas as pd
import time
#from bitmex_websocket import BitMEXWebsocket
from util.actual_kwargs import actual_kwargs
from util.api_key import generate_nonce, generate_signature
import websocket
import threading
import urlparse
import json
import string
from time import sleep
import numpy as np
import sys

class MerantixBitMex():

    # Don't grow a table larger than this amount. Helps cap memory usage.
    MAX_TABLE_LEN = 200

    @actual_kwargs()
    def __init__(self, endpoint=None, symbol=None, api_key=None, api_secret=None,num_of_levels=10):
        self.symbol = symbol
        self.num_of_levels = num_of_levels
        self.__validate(self.__init__.actual_kwargs)
        self.__reset(self.__init__.actual_kwargs)
        wsURL = self.__get_url()
        self.__connect(wsURL, symbol)
        # Connected. Wait for partials
        self.__wait_for_symbol(symbol)
        if api_key:
            self.__wait_for_account()

    def __validate(self, kwargs):
        '''Simple method that ensure the user sent the right args to the method.'''
        if 'symbol' not in kwargs:
            print("A symbol must be provided to MerantixBitMexWebSocket()")
            sys.exit(1)
        if 'endpoint' not in kwargs:
            print("An endpoint (BitMEX URL) must be provided to MerantixBitMexWebSocket()")
            sys.exit(1)
        if 'api_key' not in kwargs:
            print("No authentication provided! Unable to connect.")
            sys.exit(1)

    def __reset(self, kwargs):
        '''Resets internal datastores.'''
        self.data = {}
        self.keys = {}
        self.config = kwargs
        self.exited = False

    def __wait_for_account(self):
        '''On subscribe, this data will come down. Wait for it.'''
        # Wait for the keys to show up from the ws
        while not {'margin', 'position', 'order', 'orderBook10'} <= set(self.data):
            sleep(0.1)

    def __wait_for_symbol(self, symbol):
        '''On subscribe, this data will come down. Wait for it.'''
        while not {'instrument', 'trade', 'quote','orderBook10'} <= set(self.data):
            sleep(0.1)

    def __connect(self, wsURL, symbol):
        '''Connect to the websocket in a thread.'''
        print("Starting thread")

        self.ws = websocket.WebSocketApp(wsURL,
                                         on_message=self.__on_message,
                                         on_close=self.__on_close,
                                         on_open=self.__on_open,
                                         on_error=self.__on_error,
                                         header=self.__get_auth())

        self.wst = threading.Thread(target=lambda: self.ws.run_forever())
        self.wst.daemon = True
        self.wst.start()
        print("Started thread")

        # Wait for connect before continuing
        conn_timeout = 5
        while not self.ws.sock or not self.ws.sock.connected and conn_timeout:
            sleep(1)
            conn_timeout -= 1
        if not conn_timeout:
            print("Couldn't connect to WS! Exiting.")
            self.exit()
            sys.exit(1)

    def __get_auth(self):
        '''Return auth headers. Will use API Keys if present in settings.'''
        if self.config['api_key']:
            print("Authenticating with API Key.")
            # To auth to the WS using an API key, we generate a signature of a nonce and
            # the WS API endpoint.
            nonce = generate_nonce()
            return [
                "api-nonce: " + str(nonce),
                "api-signature: " + generate_signature(self.config['api_secret'], 'GET', '/realtime', nonce, ''),
                "api-key:" + self.config['api_key']
            ]
        else:
            print("Not authenticating.")
            return []

    def __on_error(self, ws, error):
        '''Called on fatal websocket errors. We exit on these.'''
        if not self.exited:
            print('on error function called')
            print("Error : %s" % error)
            sys.exit(1)

    def __on_open(self, ws):
        '''Called when the WS opens.'''
        print("Websocket Opened.")

    def __on_close(self, ws):
        '''Called on websocket close.'''
        print('Websocket Closed')
        sys.exit(1)

    #converts the timestamp into nanoseconds
    def convert_timestamp_to_nanosecond(self,x):
        # TODO: Validate that the correct format in nanoseconds is being produced
        return int((time.mktime(x.to_pydatetime().timetuple()) + x.to_pydatetime().microsecond/1e6)*1e3)

    def construct_order_book(self,row,label,new_label):

        # TODO: Check that these are in fact ordered as they are taken from the API.
        for i in range(0,self.num_of_levels):

            try:
                row[new_label+ '_' +str(i)] = float(row[label][i][0])
                row[new_label+ '_qty_' +str(i)] = float(row[label][i][1])
            except:
                row[new_label+ '_qty_' +str(i)] = float(-9999.0)
                row[new_label+ '_' +str(i)] = float(-9999.0)

        return row

    def __save_to_disk(self):
        print('Saving..')
        #print(self.data['orderBook10'])
        #print(self.data[0])
        ret_df = pd.DataFrame(self.data['orderBook10'])
        print(ret_df)
        #if(ret_df.empty):
        #    return
        ret_df['timestamp'] = pd.to_datetime(ret_df['timestamp'])

        # TODO: Check out the other option - ret_df['timestamp'] = pd.to_datetime(ret_df['timestamp'])#.astype(int)
        ret_df['timestamp'] = ret_df['timestamp'].apply(lambda x: self.convert_timestamp_to_nanosecond(x))
        ret_df.index = ret_df['timestamp']
        ret_df.drop('timestamp',1,inplace=True)

        # Format the order book for bid and offers
        ret_df = ret_df.apply(self.construct_order_book,args=['bids','bid'],axis=1).drop('bids',1)
        ret_df = ret_df.apply(self.construct_order_book,args=['asks','ask'],axis=1).drop('asks',1)

        # Crate the funky dataFrame format using multi indexing on the columns
        index_array = []
        for i in range(0,self.num_of_levels):
            index_array.append(('bid',str(i)))
            index_array.append(('bid_qty',str(i)))
            index_array.append(('ask',str(i)))
            index_array.append(('ask_qty',str(i)))

        index = pd.MultiIndex.from_tuples(index_array)

        df = pd.DataFrame(None, index=index)
        df = df.T

        for i in range(0,self.num_of_levels):
            df.loc[:,('bid',str(i))] = ret_df.loc[:,'bid_'+str(i)]
            df.loc[:,('bid_qty',str(i))] = ret_df.loc[:,'bid_qty_'+str(i)]
            df.loc[:,('ask',str(i))] = ret_df.loc[:,'ask_'+str(i)]
            df.loc[:,('ask_qty',str(i))] = ret_df.loc[:,'ask_qty_'+str(i)]


        hdf = pd.HDFStore('merantix_proj'+'_'+str(self.symbol)+'.h5')
        hdf.append('data', df,format='table')
        hdf.close()

        df2 = pd.read_hdf('merantix_proj'+'_'+str(self.symbol)+'.h5','data')
        print(df2.tail(5))


    def __on_message(self, ws, message):
        '''Handler for parsing WS messages.'''
        message = json.loads(message)

        table = message['table'] if 'table' in message else None
        action = message['action'] if 'action' in message else None
        try:
            if 'subscribe' in message:
                if message['success']:
                    print("Subscribed to %s." % message['subscribe'])
                else:
                    print("Unable to subscribe to %s. Error: \"%s\" Please check and restart." %
                               (message['request']['args'][0], message['error']))
            elif 'status' in message:
                if message['status'] == 400:
                    self.exit()
                if message['status'] == 401:
                    print("Either API Key incorrect or using testnet, please check and restart.")
            elif action:

                if table not in self.data:
                    self.data[table] = []

                if table not in self.keys:
                    self.keys[table] = []

                # There are four possible actions from the WS:
                # 'partial' - full table image
                # 'insert'  - new row
                # 'update'  - update row
                # 'delete'  - delete row
                if action == 'partial':
                    print("%s: partial" % table)
                    self.data[table] += message['data']
                    # Keys are communicated on partials to let you know how to uniquely identify
                    # an item. We use it for updates.
                    self.keys[table] = message['keys']

                    if( table == 'orderBook10'):
                        self.__save_to_disk()

                elif action == 'insert':
                    print('%s: inserting %s' % (table, message['data']))
                    self.data[table] += message['data']

                    # Limit the max length of the table to avoid excessive memory usage.
                    # Don't trim orders because we'll lose valuable state if we do.
                    if table != 'order' and len(self.data[table]) > BitMEXWebsocket.MAX_TABLE_LEN:
                        self.data[table] = self.data[table][(BitMEXWebsocket.MAX_TABLE_LEN // 2):]

                    if( table == 'orderBook10'):
                        self.__save_to_disk()

                elif action == 'update':
                    print('%s: updating %s' % (table, message['data']))
                    # Locate the item in the collection and update it.
                    for updateData in message['data']:
                        item = findItemByKeys(self.keys[table], self.data[table], updateData)
                        if not item:
                            continue  # No item found to update. Could happen before push

                        # Log executions
                        if table == 'order':
                            is_canceled = 'ordStatus' in updateData and updateData['ordStatus'] == 'Canceled'
                            if 'cumQty' in updateData and not is_canceled:
                                contExecuted = updateData['cumQty'] - item['cumQty']
                                if contExecuted > 0:
                                    instrument = self.get_instrument(item['symbol'])
                                    print("Execution: %s %d Contracts of %s at %.*f" %
                                             (item['side'], contExecuted, item['symbol'],
                                              instrument['tickLog'], item['price']))

                        # Update this item.
                        item.update(updateData)

                        # Remove canceled / filled orders
                        if table == 'order' and item['leavesQty'] <= 0:
                            self.data[table].remove(item)

                    if( table == 'orderBook10'):
                        self.__save_to_disk()

                elif action == 'delete':
                    print('%s: deleting %s' % (table, message['data']))
                    # Locate the item in the collection and remove it.
                    for deleteData in message['data']:
                        item = findItemByKeys(self.keys[table], self.data[table], deleteData)
                        self.data[table].remove(item)

                    if( table == 'orderBook10'):
                        self.__save_to_disk()
                else:
                    raise Exception("Unknown action: %s" % action)
        except:
            print(traceback.format_exc())

    def exit(self):
        '''Call this to exit - will close websocket.'''
        print('Calling an exit')
        self.exited = True
        self.ws.close()

    def __get_url(self):
        '''
        Generate a connection URL. We can define subscriptions right in the querystring.
        Most subscription topics are scoped by the symbol we're listening to.
        '''

        # You can sub to orderBookL2 for all levels, or orderBook10 for top 10 levels & save bandwidth
        symbolSubs = ["execution", "instrument", "order", "orderBook10","position", "quote", "trade"]
        genericSubs = ["margin"]

        subscriptions = [sub + ':' + self.config['symbol'] for sub in symbolSubs]
        subscriptions += genericSubs

        urlParts = list(urlparse.urlparse(self.config['endpoint']))
        urlParts[0] = urlParts[0].replace('http', 'ws')
        urlParts[2] = "/realtime?subscribe=" + string.join(subscriptions, ",")
        return urlparse.urlunparse(urlParts)


def findItemByKeys(keys, table, matchData):
    for item in table:
        matched = True
        for key in keys:
            if item[key] != matchData[key]:
                matched = False
        if matched:
            return item
#XBTUSD BCHZ17
socket = MerantixBitMex(endpoint="https://testnet.bitmex.com/api/v1",
                        symbol='XBTUSD',
                        api_key='gHHAPQJYXFXJjKamJ9vzFJqP',
                        api_secret='MkgYfxBRw9qbfA_npeqxLQ7BckQrS5dDdOjeLnLWUHZSQAB0')
while(socket.ws.sock.connected):
    continue
