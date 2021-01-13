/******************************************************************************************************************
FILENAME :
	Wrapper.h
DESCRIPTION :
	Provides a set of functions that wrap the STLink Bridge API for use in a .NET environment.
PUBLIC FUNCTIONS :
AUTHOR(s) :
	Alexander Andersson
START DATE : 2020-03-02
*******************************************************************************************************************/

#pragma once
#include "stlink_interface.h"
#include "bridge.h"
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;


namespace STLinkCLRWrapper
{
    // Structure used to contain the device info data for CLR, copied and modified from stlink_interface.h
    public ref struct DeviceInfo
    {
        property uint32_t StLinkUsbId; ///< ST-LINK-SERVER Device cookie in little endian format, to use in STLINK_TCP_CMD_OPEN_DEVICE
        property String^ EnumUniqueId; ///< Unique instance ID from system enumeration (equal to
                                                   ///< device Serial number in some cases, but not always ...)
        property uint16_t VendorId;  ///< Vendor  ID from USB device descriptor (system enumeration)
        property uint16_t ProductId; ///< Product ID from USB device descriptor (system enumeration)
        property bool     DeviceUsed; ///< On windows, equal to 1 if device interface was already opened from 
                            ///< externally when enumerating or trying to open
        // NOTE: do not modify the existing fields in the structure. But for any evolution,
        // add a new field at the end in order to keep ascendant compatibility.
    };

    public ref class Wrapper
    {
    private:
        STLinkInterface* sTLinkInterface = NULL;
        Brg* Bridge = NULL;
        //STLink_DeviceInfo2T* deviceInfo = NULL;
        Brg_StatusT BridgeStatus = Brg_StatusT::BRG_NO_ERR;
        STLinkIf_StatusT InterfaceStatus = STLinkIf_StatusT::NO_ERR;
        //const char* StringToCharPtr(String^ s);
        Brg_StatusT CanMsgTxRxVerif(Brg_CanTxMsgT *pCanTxMsg, uint8_t *pDataTx, Brg_CanRxMsgT *pCanRxMsg, uint8_t *pDataRx, Brg_CanRxFifoT rxFifo, uint8_t size);
    public:
        Wrapper();
        ~Wrapper();
		!Wrapper();


        Brg_StatusT InitBridge(DeviceInfo^ device);
        STLinkIf_StatusT GetInterfaceStatus();
        Brg_StatusT GetBridgeStatus();

		STLinkIf_StatusT EnumerateDevices([Out] List<DeviceInfo^>^% results);
        Brg_StatusT      OpenBridge(DeviceInfo^ device);
        Brg_StatusT      TestVoltage([Out] float% result);
		Brg_StatusT      TestGetClock();
		Brg_StatusT		 GPIOInit();
		Brg_StatusT		 GPIOWrite();
		Brg_StatusT		 CanTest();
        Brg_StatusT      CanInit(uint32_t reqBaudrate);
        
	};
}