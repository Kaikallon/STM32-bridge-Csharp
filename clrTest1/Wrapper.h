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


namespace STLinkBridgeWrapper
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

    //public ref struct CANMessage 
    //{
    //    uint32_t id;
    //    array<Byte^>^ data = gcnew array<Byte^>(8); // bytes object
    //    bool remote;
    //    bool extended;
    //};

    public ref struct CanBridgeMessage
    {
        bool     IdExtended;       ///< Specifies if ID is standard (11-bit) or extended (29-bit) identifier.
        uint32_t ID;               ///< Identifier of the message (11bit or 29bit according to IDE).
        bool     RTR;              ///< Remote Frame Request or data frame message type.
        uint8_t  DLC;              ///< Data Length Code is the number of data bytes in the received message 
                                   ///< or number of data bytes requested by RTR.
        bool     Fifo;             ///< Fifo in which the message was received (according to Filter initialization done
                                   ///< with Brg::InitFilterCAN(): AssignedFifo in #Brg_CanFilterConfT)
        bool OverrunFIFO;          ///< Indicate if overrun has occurred before this message. STLink CAN HW fifo overrun
        bool OverrunBuffer;        ///< Indicate if overrun has occurred before this message. STLink CAN Rx buffer overrun
        uint16_t CanTimeStamp;     ///< unused
        int64_t TimeStamp;         // Computer time at recieval
        array<Byte>^ data = gcnew array<Byte>(8);

    } ;

    public ref class Wrapper
    {
    private:
        STLinkInterface* sTLinkInterface = NULL;
        Brg* Bridge = NULL;

    protected:
        Brg_StatusT      BridgeStatus = Brg_StatusT::BRG_NO_ERR;
        STLinkIf_StatusT InterfaceStatus = STLinkIf_StatusT::NO_ERR;
        Brg_StatusT      CanMsgTxRxVerif(Brg_CanTxMsgT *pCanTxMsg, uint8_t *pDataTx, Brg_CanRxMsgT *pCanRxMsg, uint8_t *pDataRx, Brg_CanRxFifoT rxFifo, uint8_t size);
        Brg_StatusT      StartTransmission();
        Brg_StatusT      StopTransmission();
    public:
        Wrapper();
        ~Wrapper();
		!Wrapper();


        Brg_StatusT      InitBridge(DeviceInfo^ device);
        STLinkIf_StatusT GetInterfaceStatus();
        Brg_StatusT      GetBridgeStatus();

		STLinkIf_StatusT EnumerateDevices([Out] List<DeviceInfo^>^% results);
        Brg_StatusT      OpenBridge(DeviceInfo^ device);
        Brg_StatusT      TestVoltage([Out] float% result);
		Brg_StatusT      TestGetClock();
		Brg_StatusT		 GPIOInit();
		Brg_StatusT		 GPIOWrite();
		Brg_StatusT		 CanTest();
        Brg_StatusT      CanInit(uint32_t RequestedBaudrate, bool loopback );
        Brg_StatusT      CanInit(uint32_t RequestedBaudrate, Brg_CanInitT canParam);

        Brg_StatusT      CanRead([Out] List<CanBridgeMessage^>^% results);
        Brg_StatusT      CanWrite(CanBridgeMessage^ message);

	};
}