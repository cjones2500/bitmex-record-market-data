Getting Started

This is a clone of the main bitmex api-connectors but with some changes made to remove the logging functions that they have built into the Bitmex websocket class. 

In order to run this in Python,

> $ python /bitmex-record-market-data/official-ws/python/merantix_project.py 

The choice of bitcoin contract can be changed within the file (this defaults to XBTUSD) and a matplotlib plot of TOB is plotted as the data is recorded (as a cross check)

