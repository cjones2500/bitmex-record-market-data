import pandas as pd
import matplotlib.pyplot as plt
import numpy as np

def check_symbol(symbol):
    df = pd.read_hdf('merantix_proj'+'_'+str(symbol)+'.h5','data')
    #print(df.tail(5))

    t = df.index.values
    bid_tob = df.loc[:,('bid','0')].values
    offer_tob = df.loc[:,('ask','0')].values
    bid_qty = df.loc[:,('bid_qty','0')].values
    ask_qty = df.loc[:,('ask_qty','0')].values


    plt.clf()
    plt.plot(t, bid_tob, label='Bid TOB')
    plt.plot(t, offer_tob, label='Ask TOB')
    plt.xlabel('time (s)')
    plt.ylabel(str(symbol) + ' in USD')
    plt.legend(bbox_to_anchor=(0., 1.02, 1., .102), loc=3,
           ncol=2, mode="expand", borderaxespad=0.)
    plt.savefig(str(symbol)+".png")



check_symbol('XBTUSD')
check_symbol('BCHZ17')
