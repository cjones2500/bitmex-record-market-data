import pandas
from bitmex_websocket import BitMEXWebsocket
import logging

class BitMexTrader(symbol):
    def __init__(self):
        self.symbol = symbol


    def connect_to_api(self):
        # Instantiating the WS will make it connect. Be sure to add your api_key/api_secret.
        ws = BitMEXWebsocket(endpoint="https://testnet.bitmex.com/api/v1", symbol=symbol,
                             api_key=None, api_secret=None)
        print(ws)

test = BitMexTrader('XBTUSD')
