# GoodweCommunicatorDesktop

GoodweCommunicatorDesktop is a simple desktop application built with WinUI 3 for communicating with GoodWe inverter devices.  
The application has been tested with the [GoodWe GW10KN-ET](https://cz.goodwe.com/et-plus-16a) model.  

It allows users to read and write Modbus registers from GoodWe devices over a network connection.

## Features
- Built with WinUI 3 for Windows desktop.  
- Supports Modbus RTU over UDP protocol.  
- Read and write registers on GoodWe inverters.  
- Tested with GoodWe GW10KN-ET inverter.

## Getting Started
1. Launch the application.  
2. Enter the inverter connection parameters:  
   - IP address of the inverter  
   - Port (usually: 8899)  
   - Device address (usually: 247)  
3. Use the interface to read or write Modbus registers.  

## Protocol
- Communication is based on Modbus RTU over UDP.  
- Register addresses and values follow the official GoodWe documentation.  

## Disclaimer
This is an independent open-source project, not affiliated with GoodWe.  
Use at your own risk when writing registers, as incorrect values may affect device operation.
