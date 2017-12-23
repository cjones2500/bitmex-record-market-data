import pandas as pd
df2 = pd.read_hdf('/Users/cjones/Downloads/data_merantix.h5', key="data")
print(df2.columns.values)

#print(df2['bid'])

print(type(df2['bid']))

#print(df2[('bid','0')])

print(df2['bid'][0])
