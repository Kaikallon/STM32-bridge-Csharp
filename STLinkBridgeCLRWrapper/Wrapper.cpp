/******************************************************************************************************************
FILENAME :
	Wrapper.cpp
DESCRIPTION :
	Provides a set of functions that wrap the STLink Bridge API for use in a .NET environment.
PUBLIC FUNCTIONS :
AUTHOR(s) :
	Alexander Andersson
START DATE : 2020-03-02
*******************************************************************************************************************/

#include "stdafx.h"
#include "Wrapper.h"
using namespace System;
using namespace STLinkBridgeWrapper;
using namespace System::Diagnostics;


STLinkBridgeWrapperCpp::STLinkBridgeWrapperCpp()
{
    // Create USB BRIDGE interface
	this->sTLinkInterface = new STLinkInterface(STLINK_BRIDGE);


#ifdef USING_ERRORLOG
    // Note: cErrLog g_ErrLog; to be instanciated and initialized if used with USING_ERRORLOG
    sTLinkInterface->BindErrLog(&g_ErrLog);
#endif

    // Load STLinkUSBDriver library
    InterfaceStatus = sTLinkInterface->LoadStlinkLibrary("");

    BridgeStatus = Brg::ConvSTLinkIfToBrgStatus(InterfaceStatus);
    // Initiate bridge
    if (BridgeStatus == Brg_StatusT::BRG_NO_ERR)
    {
        Bridge = new Brg(*sTLinkInterface);
#ifdef USING_ERRORLOG
        Bridge->BindErrLog(&g_ErrLog);
#endif
    }
    else
    {
        // TODO: Throw error
    }
}

STLinkBridgeWrapperCpp::~STLinkBridgeWrapperCpp()
{
	this->!STLinkBridgeWrapperCpp();
}

STLinkBridgeWrapperCpp::!STLinkBridgeWrapperCpp()
{
	//delete deviceInfo;
	//deviceInfo = NULL;

	// Disconnect
	if (Bridge != NULL)
	{
        CloseBridge();

		delete Bridge;
		Bridge = NULL;
	}
	// unload STLinkUSBdriver library
	if (sTLinkInterface != NULL)
	{
		// always delete STLinkInterface after Brg (because Brg uses STLinkInterface)
		delete sTLinkInterface;
		sTLinkInterface = NULL;
	}
}

void STLinkBridgeWrapperCpp::CloseBridge()
{
    if (TransmissionRunning)
        StopTransmission();
    Bridge->CloseBridge(COM_UNDEF_ALL);
    Bridge->CloseStlink();
    //delete Bridge;
    //Bridge = NULL;
}

STLinkIf_StatusT STLinkBridgeWrapperCpp::GetInterfaceStatus()
{
    return this->InterfaceStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::GetBridgeStatus()
{
    uint32_t numDevices;
    // Calling a EnumDevices seems to be a hack in order to get the lates status
    BridgeStatus = Brg::ConvSTLinkIfToBrgStatus(sTLinkInterface->EnumDevices(&numDevices, false)); 
    return this->BridgeStatus;
}

STLinkIf_StatusT STLinkBridgeWrapperCpp::EnumerateDevices([Out] List<DeviceInfo^>^% results)
{
    uint32_t numDevices;
    // Safety check
    switch (InterfaceStatus)
    {
    case STLinkIf_StatusT::NO_ERR:
    case STLinkIf_StatusT::NO_STLINK:
    case STLinkIf_StatusT::SN_NOT_FOUND:
        break;
    case STLinkIf_StatusT::CONNECT_ERR:
    case STLinkIf_StatusT::DLL_ERR:
    case STLinkIf_StatusT::USB_COMM_ERR:
    case STLinkIf_StatusT::PARAM_ERR:
    case STLinkIf_StatusT::NOT_SUPPORTED:
    case STLinkIf_StatusT::PERMISSION_ERR:
    case STLinkIf_StatusT::ENUM_ERR:
    case STLinkIf_StatusT::GET_INFO_ERR:
    case STLinkIf_StatusT::CLOSE_ERR:
        Console::WriteLine("STLinkUSBDriver library (dll) issue");
        return InterfaceStatus;
        break;
    }

    //DeviceInfo^ mock = gcnew DeviceInfo();
    //mock->DeviceUsed = false;
    //mock->EnumUniqueId = "Mock adapter";
    //results->Add(mock);

    // Do the enumeration, find the total number of devices
    InterfaceStatus = sTLinkInterface->EnumDevices(&numDevices, false);

    // Check if it is okay to proceed.
    if (!((InterfaceStatus == STLinkIf_StatusT::NO_ERR) || (InterfaceStatus == STLinkIf_StatusT::PERMISSION_ERR)))
    {
        Console::WriteLine("Error: " + InterfaceStatus.ToString());
        return InterfaceStatus;
    }

    Console::WriteLine(numDevices.ToString() + " BRIDGE device(s) found");
    // Store the enumerated devices
    for (uint32_t i = 0; i < numDevices; i++)
    {
        STLink_DeviceInfo2T tempDeviceInfo;
        InterfaceStatus = sTLinkInterface->GetDeviceInfo2(i, &tempDeviceInfo, sizeof(tempDeviceInfo));

        // Allocate and perform manual copy
		DeviceInfo^ devInfo = gcnew DeviceInfo();
        devInfo->DeviceUsed = tempDeviceInfo.DeviceUsed;
        devInfo->EnumUniqueId = gcnew String(tempDeviceInfo.EnumUniqueId);
        devInfo->ProductId = tempDeviceInfo.ProductId;
        devInfo->StLinkUsbId = tempDeviceInfo.DeviceUsed;
        devInfo->VendorId = tempDeviceInfo.VendorId;
        results->Add(devInfo);
    }


    BridgeStatus = Brg::ConvSTLinkIfToBrgStatus(InterfaceStatus);
    return InterfaceStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::OpenBridge(DeviceInfo^ device)
{
    if (Bridge == NULL)
    {
        // TODO: Consider throwing exception
        return BridgeStatus;
    }

    // Check for errors
    if (GetBridgeStatus() != Brg_StatusT::BRG_NO_ERR)
    {
        return BridgeStatus;
    }

    // Open the STLink connection
    Bridge->SetOpenModeExclusive(true); // TODO: Research exclusive mode and consider setting to false
                                         // Note: Exclusive mode is recommended by ST when running the 
                                         // link in bridge mode, but it is not clear why.

	char* tempChar = (char*)(void*)Marshal::StringToHGlobalAnsi(device->EnumUniqueId);
    BridgeStatus = Bridge->OpenStlink(tempChar, true);
	Marshal::FreeHGlobal((IntPtr)tempChar);

    if (BridgeStatus == Brg_StatusT::BRG_NOT_SUPPORTED)
    {
		uint32_t numDevices;
        BridgeStatus = GetBridgeStatus();
        Console::WriteLine(String::Format("BRIDGE not supported PID: 0x{0} SN:%{1}", device->ProductId.ToString("X"), device->EnumUniqueId));
		// TODO: Throw exception 
    }

    if (BridgeStatus == Brg_StatusT::BRG_OLD_FIRMWARE_WARNING)
    {
        BridgeStatus = Brg_StatusT::BRG_NO_ERR;
    }

    return BridgeStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::GetTargetVoltage([Out] float% result) 
{
    if (Bridge == NULL)
    {
        // TODO: Consider throwing exception
        return BridgeStatus;
    }
    // Test Voltage command
    if (GetBridgeStatus() == Brg_StatusT::BRG_NO_ERR)
    {
        float voltage = 0;
        // T_VCC pin must be connected to target voltage on debug connector
        BridgeStatus = Bridge->GetTargetVoltage(&voltage);
        result = voltage;
    }

    return BridgeStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::TestGetClock()
{
	// Test GET CLOCK command
	if (GetBridgeStatus() == Brg_StatusT::BRG_NO_ERR) 
    {
		uint32_t StlHClkKHz, comInputClkKHz;
		// Get the current bridge input Clk for all com:
		BridgeStatus = Bridge->GetClk(COM_SPI, (uint32_t*)&comInputClkKHz, (uint32_t*)&StlHClkKHz);
		Console::WriteLine("SPI input CLK: {0} kHz, ST-Link HCLK: {1} kHz", (int)comInputClkKHz, (int)StlHClkKHz);
		if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
			BridgeStatus = Bridge->GetClk(COM_I2C, (uint32_t*)&comInputClkKHz, (uint32_t*)&StlHClkKHz);
			Console::WriteLine("I2C input CLK: {0} kHz, ST-Link HCLK: {1} kHz", (int)comInputClkKHz, (int)StlHClkKHz);
		}
		if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
			BridgeStatus = Bridge->GetClk(COM_CAN, (uint32_t*)&comInputClkKHz, (uint32_t*)&StlHClkKHz);
			Console::WriteLine("CAN input CLK: {0} kHz, ST-Link HCLK: {1} kHz", (int)comInputClkKHz, (int)StlHClkKHz);
		}
		if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
			BridgeStatus = Bridge->GetClk(COM_GPIO, (uint32_t*)&comInputClkKHz, (uint32_t*)&StlHClkKHz);
			Console::WriteLine("GPIO input CLK: {0} kHz, ST-Link HCLK: {1} kHz", (int)comInputClkKHz, (int)StlHClkKHz);
		}
		if (BridgeStatus != Brg_StatusT::BRG_NO_ERR) {
			Console::WriteLine("Error in GetClk()");
		}
	}
	return BridgeStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::GPIOInit()
{
	if (BridgeStatus == Brg_StatusT::BRG_NO_ERR)
	{
		uint8_t bridgeCom = COM_GPIO; //Used to tell the bridge that we want to do GPIO operations
		Brg_GpioInitT gpioParams;
		Brg_GpioConfT gpioConf[BRG_GPIO_MAX_NB];
		uint8_t gpioMask = 0, gpioErrMsk;

		if (bridgeCom == COM_GPIO) 
		{
			Console::WriteLine("Run BRIDGE GPIO test");
		}
		else 
		{
			BridgeStatus = Brg_StatusT::BRG_NOT_SUPPORTED;
		}

		// Set GPIO mode
		if (BridgeStatus == Brg_StatusT::BRG_NO_ERR)
		{
			gpioMask = BRG_GPIO_ALL; // BRG_GPIO_0 1 2 3
			gpioParams.GpioMask = gpioMask; 
			gpioParams.ConfigNb = BRG_GPIO_MAX_NB; // Must be BRG_GPIO_MAX_NB or 1 (if 1 pGpioConf[0] used for all gpios)
			gpioParams.pGpioConf = &gpioConf[0]; // Point to table of init configurations
			for (int i = 0; i < BRG_GPIO_MAX_NB; i++) 
			{
				// Assign mode to each pin
				gpioConf[i].Mode = GPIO_MODE_OUTPUT;
				gpioConf[i].Speed = GPIO_SPEED_MEDIUM;
				gpioConf[i].Pull = GPIO_NO_PULL;
				gpioConf[i].OutputType = GPIO_OUTPUT_PUSHPULL;
			}
			BridgeStatus = Bridge->InitGPIO(&gpioParams);
			if (BridgeStatus != Brg_StatusT::BRG_NO_ERR)
			{
				Console::WriteLine(String::Format("Bridge Gpio init failed (mask={0}, gpio0: mode= {1}, pull = {2}, ...)\n",
					(int)gpioParams.GpioMask, (int)gpioConf[0].Mode, (int)gpioConf[0].Pull)); // TODO: Change enums to public enum class for better readability of error messages
			}
		}


	}
	return BridgeStatus;

}

Brg_StatusT STLinkBridgeWrapperCpp::GPIOWrite()
{
	Brg_GpioValT gpioReadVal[BRG_GPIO_MAX_NB] = { GPIO_RESET , GPIO_SET , GPIO_RESET , GPIO_SET };
	uint8_t gpioMask = BRG_GPIO_ALL;
	uint8_t gpioErrMsk;


	// Test GPIO
	if (BridgeStatus == Brg_StatusT::BRG_NO_ERR)
	{
		BridgeStatus = Bridge->SetResetGPIO(gpioMask, &gpioReadVal[0], &gpioErrMsk);
		if ((BridgeStatus != Brg_StatusT::BRG_NO_ERR) || (gpioErrMsk != 0))
		{
			Console::WriteLine("Bridge Read error");
		}
		else 
		{
			// Verify all gpio read to 1 (input pull up)
			for (int i = 0; i < BRG_GPIO_MAX_NB; i++)
			{
				if (gpioReadVal[i] != GPIO_SET) 
				{
					BridgeStatus = Brg_StatusT::BRG_VERIF_ERR;
					Console::WriteLine("Bridge Read Verif error ( gpio {0} != SET)", i);
				}
			}
		}
	}

	if (BridgeStatus == Brg_StatusT::BRG_NO_ERR)
	{
		Console::WriteLine("GPIO Test1 OK");
	}
	return BridgeStatus;
}



// Simple version of CanInit with only baud rate as selectable parameter.
// See http://www.bittiming.can-wiki.info/ for clues about how to select the bit timing parameters
Brg_StatusT STLinkBridgeWrapperCpp::CanInit(uint32_t RequestedBaudrate, bool loopback)
{
    Brg_CanInitT canParam;
    uint32_t prescal;
    uint32_t finalBaudrate = 0; // TODO: Return this

    // N=sync+prop+seg1+seg2= 1+2+7+6= 16, 125000 bps (-> prescal = 24 = (CanClk = 48MHz)/(16*125000))
    canParam.BitTimeConf.PropSegInTq   = 2;
    canParam.BitTimeConf.PhaseSeg1InTq = 7;
    canParam.BitTimeConf.PhaseSeg2InTq = 6;
    canParam.BitTimeConf.SjwInTq       = 3;

    canParam.Mode = loopback ? CAN_MODE_LOOPBACK : CAN_MODE_NORMAL;
    canParam.bIsTxfpEn = false;
    canParam.bIsRflmEn = false;
    canParam.bIsNartEn = false;
    canParam.bIsAwumEn = false;
    canParam.bIsAbomEn = false;

    BridgeStatus = CanInit(RequestedBaudrate, canParam);


    return BridgeStatus;
}

// More advanced version of CanInit with all options exposed.
Brg_StatusT STLinkBridgeWrapperCpp::CanInit(uint32_t RequestedBaudrate, Brg_CanInitT canParam)
{
    uint32_t prescal;
    uint32_t finalBaudrate = 0; // TODO: Return this

    BridgeStatus = Bridge->GetCANbaudratePrescal(&canParam.BitTimeConf, RequestedBaudrate, (uint32_t*)&prescal, (uint32_t*)&finalBaudrate);

    if (BridgeStatus == Brg_StatusT::BRG_COM_FREQ_NOT_SUPPORTED)
    { 
        throw gcnew Exception("ERROR: Bridge CAN init baudrate " + RequestedBaudrate + " bps not possible (invalid prescaler: " + prescal + ") change Bit Time or baudrate settings.");
    }
    else if (BridgeStatus == Brg_StatusT::BRG_NO_ERR)
    {
        canParam.Prescaler = prescal;
        BridgeStatus = Bridge->InitCAN(&canParam, BRG_INIT_FULL); // Note: This requires a CAN tranceiver to be connected
        if (BridgeStatus == Brg_StatusT::BRG_CAN_ERR)
        {
            throw gcnew Exception("ERROR: No tranceiver connected."); 
        }
        else if (BridgeStatus != Brg_StatusT::BRG_NO_ERR)
        {
            throw gcnew Exception("ERROR: " + BridgeStatus.ToString());
        }
    }

    return BridgeStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::CanReadLL([Out] List<CanMessage^>^% results, [Out] bool OverrunDetected)
{
    // Perform safety checks
    if (Bridge == NULL)
        throw gcnew Exception("Error: Bridge not initialized.");

    // Get the number of available messages
    uint16_t canMsgNum;
    BridgeStatus = Bridge->GetRxMsgNbCAN(&canMsgNum);
    if (CheckComError(BridgeStatus))
        return BridgeStatus;
    //Debug::Assert(BridgeStatus == Brg_StatusT::BRG_NO_ERR);

    // Allocate space, and get the messages
    Brg_CanRxMsgT msg;
    uint8_t data[8]; // Allocate enough space. Note that some might go unused, depending on how many DLCs are used.
    uint16_t numberOfReceivedDataBytes;
    

    for (int i = 0; i < canMsgNum; i++)
    {
        BridgeStatus = Bridge->GetRxMsgCAN(&msg, 1, data, 8, &numberOfReceivedDataBytes); // Fetch one message at a time
        if (CheckComError(BridgeStatus))
            return BridgeStatus;
        //Debug::Assert(BridgeStatus == Brg_StatusT::BRG_NO_ERR);

        if ((msg.Overrun != CAN_RX_NO_OVERRUN))
        {
            OverrunDetected = true;
            continue;
        }

        CanMessage^ tempMessage = gcnew CanMessage();
        tempMessage->DLC           =  msg.DLC;
        tempMessage->Id            =  msg.ID;
        tempMessage->Fifo          = (msg.Fifo    == CAN_MSG_RX_FIFO1    ? true : false);
        tempMessage->IdExtended    = (msg.IDE     == CAN_ID_EXTENDED     ? true : false);
        tempMessage->RTR           = (msg.RTR     == CAN_REMOTE_FRAME    ? true : false);

        // Copy data using a temporary holder
        uint64_t tempData;
        memcpy((uint8_t*)&(tempData), data, msg.DLC);
        tempMessage->Data = tempData;

        results->Add(tempMessage);
    }

    return BridgeStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::CanReadLL2([Out] List<CanMessage^>^% results, [Out] bool OverrunDetected)
{
    // Perform safety checks
    if (Bridge == NULL)
        throw gcnew Exception("Error: Bridge not initialized.");

    // Get the number of available messages
    uint16_t canMsgNum;
    BridgeStatus = Bridge->GetRxMsgNbCAN(&canMsgNum);
    if (CheckComError(BridgeStatus))
        return BridgeStatus;
    //Debug::Assert(BridgeStatus == Brg_StatusT::BRG_NO_ERR);

    // Allocate space, and get the messages

    Brg_CanRxMsgT* messages = new Brg_CanRxMsgT[canMsgNum];
    uint8_t* dataBuffer = new uint8_t[8*canMsgNum]; // Allocate enough space. Note that some might go unused, depending on how many DLCs are used.
    uint16_t numberOfReceivedDataBytes;
    uint8_t* dataPointer = dataBuffer;

    // Read all messages
    BridgeStatus = Bridge->GetRxMsgCAN(messages, canMsgNum, dataBuffer, 8 * canMsgNum, &numberOfReceivedDataBytes);
    if (CheckComError(BridgeStatus))
        return BridgeStatus;
    for (int i = 0; i < canMsgNum; i++)
    {
        Brg_CanRxMsgT& msg = messages[i];

        if ((msg.Overrun != CAN_RX_NO_OVERRUN))
        {
            OverrunDetected = true;
            continue;
        }

        // Copy data
        CanMessage^ tempMessage = gcnew CanMessage();
        tempMessage->DLC = msg.DLC;
        tempMessage->Id = msg.ID;
        tempMessage->Fifo = (msg.Fifo == CAN_MSG_RX_FIFO1 ? true : false);
        tempMessage->IdExtended = (msg.IDE == CAN_ID_EXTENDED ? true : false);
        tempMessage->RTR = (msg.RTR == CAN_REMOTE_FRAME ? true : false);

        // Copy data using a temporary holder
        uint64_t tempData;
        memcpy((uint8_t*)&(tempData), dataPointer, msg.DLC);
        tempMessage->Data = tempData;

        results->Add(tempMessage);

        // Advance pointer
        //dataPointer += msg.DLC;
        dataPointer += 8;
    }

    // Clean up
    delete[] messages;
    delete[] dataBuffer;

    messages = NULL;
    dataBuffer = NULL;

    return BridgeStatus;
}

bool STLinkBridgeWrapperCpp::CheckComError(Brg_StatusT status)
{
    if ((status == Brg_StatusT::BRG_CONNECT_ERR)
        || (status == Brg_StatusT::BRG_USB_COMM_ERR))
        return true;
    return false;
}
Brg_StatusT STLinkBridgeWrapperCpp::CanWriteLL(CanMessage^ message)
{
    Brg_CanTxMsgT tempMessage;
    tempMessage.IDE = message->IdExtended ? CAN_ID_EXTENDED : CAN_ID_STANDARD;
    tempMessage.ID  = message->Id;
    tempMessage.RTR = message->RTR ? CAN_REMOTE_FRAME : CAN_DATA_FRAME;
    tempMessage.DLC = message->DLC;

    // Allocate
    uint8_t* dataArray = new uint8_t[tempMessage.DLC];

    // Copy data to array
    uint64_t tempData = message->Data;
    memcpy(dataArray, (uint8_t*)&tempData, tempMessage.DLC);

    // Write message
    BridgeStatus = Bridge->WriteMsgCAN(&tempMessage, dataArray, tempMessage.DLC);
    //Debug::Assert(BridgeStatus == Brg_StatusT::BRG_NO_ERR);

    // Clean up
    delete[] dataArray;
    dataArray = NULL;
    return BridgeStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::StartTransmission()
{
    BridgeStatus = Bridge->StartMsgReceptionCAN();
    if (GetBridgeStatus() != Brg_StatusT::BRG_NO_ERR)
    {
        throw gcnew Exception("CAN StartMsgReceptionCAN failed because of a pre-existing error");
    }

    // Receive all messages (no filter) with all DLC possible size (0->8)
    // Filter0: CAN prepare receive (no filter: ID_MASK with Id =0 & Mask = 0) receive all in FIFO0
    Brg_CanFilterConfT filterConf;
    int i;
    filterConf.AssignedFifo = CAN_MSG_RX_FIFO0;
    filterConf.bIsFilterEn = true;
    filterConf.FilterBankNb = 0; //0 to 13
    filterConf.FilterMode = CAN_FILTER_ID_MASK; // CAN_FILTER_ID_LIST
    filterConf.FilterScale = CAN_FILTER_16BIT; // CAN_FILTER_32BIT
    for (i = 0; i < 4; i++) 
    {
        filterConf.Id[i].ID = 0;
        filterConf.Id[i].IDE = CAN_ID_STANDARD;
        filterConf.Id[i].RTR = CAN_DATA_FRAME;
    }
    for (i = 0; i < 2; i++) 
    {
        filterConf.Mask[i].ID = 0;
        filterConf.Mask[i].IDE = CAN_ID_STANDARD;
        filterConf.Mask[i].RTR = CAN_DATA_FRAME;
    }
    if (GetBridgeStatus() == Brg_StatusT::BRG_NO_ERR) 
    {
        BridgeStatus = Bridge->InitFilterCAN(&filterConf);
        if (BridgeStatus != Brg_StatusT::BRG_NO_ERR) 
        {
            // TODO: Check for COM error to allow for more finess
            throw gcnew Exception("CAN filter init failed. Check the filter configuration.");
        }
    }

    TransmissionRunning = true;
    NotifyTransmissionChanged();

    return BridgeStatus;
}

Brg_StatusT STLinkBridgeWrapperCpp::StopTransmission()
{
    BridgeStatus = Bridge->StopMsgReceptionCAN();
    if (BridgeStatus != Brg_StatusT::BRG_NO_ERR)
    {
        throw gcnew Exception("CAN StopMsgReceptionCAN failed"); 
    }

    TransmissionRunning = false;
    NotifyTransmissionChanged();

    return BridgeStatus;
}

// This CanTest function is similar to what ST provided as a test function, but modified to work in a CLR envirnoment.
Brg_StatusT STLinkBridgeWrapperCpp::CanTest()
{
    //uint32_t currFreqKHz = 0;
    //uint8_t com = COM_CAN;
    //uint32_t StlHClkKHz, comInputClkKHz;
    //// Get the current bridge input Clk
    //BridgeStatus = Bridge->GetClk(com, &comInputClkKHz, &StlHClkKHz);
    //Console::WriteLine("CAN input CLK: {0} KHz, STLink HCLK: {1} KHz", (int)comInputClkKHz, (int)StlHClkKHz);

    // EXAMPLE FOR CAN Initialization, Brg::InitCAN(), Brg::GetCANbaudratePrescal()
    //**********[Missing init steps] * *********
    Brg_CanInitT canParam;
    uint32_t prescal;
    uint32_t reqBaudrate = 125000; //125kbps
    uint32_t finalBaudrate = 0;

    // N=sync+prop+seg1+seg2= 1+2+7+6= 16, 125000 bps (-> prescal = 24 = (CanClk = 48MHz)/(16*125000))
    canParam.BitTimeConf.PropSegInTq = 2;
    canParam.BitTimeConf.PhaseSeg1InTq = 7;
    canParam.BitTimeConf.PhaseSeg2InTq = 6;
    canParam.BitTimeConf.SjwInTq = 3;
    BridgeStatus = Bridge->GetCANbaudratePrescal(&canParam.BitTimeConf, reqBaudrate, (uint32_t*)&prescal, (uint32_t*)&finalBaudrate);
    if (BridgeStatus == Brg_StatusT::BRG_COM_FREQ_MODIFIED)
    {
        Console::WriteLine("WARNING Bridge CAN init baudrate asked {0} bps but applied {1} bps", (int)reqBaudrate, (int)finalBaudrate);
    }
    else if (BridgeStatus == Brg_StatusT::BRG_COM_FREQ_NOT_SUPPORTED)
    { // TODO: Throw exception
        Console::WriteLine("ERROR Bridge CAN init baudrate {0} bps not possible (invalid prescaler: {1}) change Bit Time or baudrate settings. \n", (int)reqBaudrate, (int)prescal);
    }
    else if (BridgeStatus == Brg_StatusT::BRG_NO_ERR)
    {
        canParam.Prescaler = prescal;
        canParam.Mode = CAN_MODE_LOOPBACK;
        canParam.bIsTxfpEn = false;
        canParam.bIsRflmEn = false;
        canParam.bIsNartEn = false;
        canParam.bIsAwumEn = false;
        canParam.bIsAbomEn = false;
        BridgeStatus = Bridge->InitCAN(&canParam, BRG_INIT_FULL); // TODO: Check for error
    }

    //// EXAMPLE FOR CAN loopback test, Brg::StartMsgReceptionCAN() Brg::InitFilterCAN() Brg::WriteMsgCAN() Brg::GetRxMsgNbCAN() Brg::GetRxMsgCAN()</B>\n
    uint8_t dataRx[8], dataTx[8];
    int i, nb;
    Brg_CanFilterConfT filterConf;
    Brg_CanRxMsgT canRxMsg;
    Brg_CanTxMsgT canTxMsg;
    uint8_t size = 0;
    uint16_t msgNb = 0;

    BridgeStatus = Bridge->StartMsgReceptionCAN();
    if (BridgeStatus != Brg_StatusT::BRG_NO_ERR) {
        Console::WriteLine("CAN StartMsgReceptionCAN failed"); // TODO: Throw exception
    }

    // Loopback_test
    // Receive all messages (no filter) with all DLC possible size (0->8)
    // Filter0: CAN prepare receive (no filter: ID_MASK with Id =0 & Mask = 0) receive all in FIFO0
    filterConf.AssignedFifo = CAN_MSG_RX_FIFO0;
    filterConf.bIsFilterEn = true;
    filterConf.FilterBankNb = 0; //0 to 13
    filterConf.FilterMode = CAN_FILTER_ID_MASK; // CAN_FILTER_ID_LIST
    filterConf.FilterScale = CAN_FILTER_16BIT; // CAN_FILTER_32BIT
    for (i = 0; i < 4; i++) {
        filterConf.Id[i].ID = 0;
        filterConf.Id[i].IDE = CAN_ID_STANDARD;
        filterConf.Id[i].RTR = CAN_DATA_FRAME;
    }
    for (i = 0; i < 2; i++) {
        filterConf.Mask[i].ID = 0;
        filterConf.Mask[i].IDE = CAN_ID_STANDARD;
        filterConf.Mask[i].RTR = CAN_DATA_FRAME;
    }
    if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
        BridgeStatus = Bridge->InitFilterCAN(&filterConf);
        if (BridgeStatus != Brg_StatusT::BRG_NO_ERR) {
            Console::WriteLine("CAN filter0 init failed"); // TODO: Throw exception
        }
    }

    canRxMsg.ID = 0;
    canRxMsg.IDE = CAN_ID_EXTENDED; // must be = canTxMsg.IDE for the test
    canRxMsg.RTR = CAN_DATA_FRAME; // must be = canTxMsg.RTR for the test
    canRxMsg.DLC = 0;

    canTxMsg.ID = 0x12345678; // must be <=0x7FF for CAN_ID_STANDARD, <=0x1FFFFFFF
    canTxMsg.IDE = CAN_ID_EXTENDED;
    canTxMsg.RTR = CAN_DATA_FRAME;
    canTxMsg.DLC = 0;

    nb = 0;
    while ((BridgeStatus == Brg_StatusT::BRG_NO_ERR) && (nb < 255)) {

        for (i = 0; i < 8; i++) {
            dataRx[i] = 0;
            dataTx[i] = (uint8_t)(nb + i);
        }
        canRxMsg.DLC = 0;
        canTxMsg.DLC = 2; // unused in CAN_DATA_FRAME
        size = (uint8_t)(nb % 9); // try 0 to 8 DLC size

        if (nb == 200) { // do it only once
            // REINIT command with same settings must be transparent and  must not break filter configuration
            BridgeStatus = Bridge->InitCAN(&canParam, BRG_REINIT);
        }
        if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
            BridgeStatus = CanMsgTxRxVerif(&canTxMsg, dataTx, &canRxMsg, dataRx, CAN_MSG_RX_FIFO0, size);
        }
        nb++;
    }
    if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
        Console::WriteLine(" Loopback_test1 OK");
    }
    return BridgeStatus;
}

// This CanTest function is similar to what ST provided as a test function, but modified to work in a CLR envirnoment.
// send a message and verify it is received and that TX = Rx
Brg_StatusT STLinkBridgeWrapperCpp::CanMsgTxRxVerif(Brg_CanTxMsgT *pCanTxMsg, uint8_t *pDataTx, Brg_CanRxMsgT *pCanRxMsg, uint8_t *pDataRx, Brg_CanRxFifoT rxFifo, uint8_t size)
{
    uint16_t msgNb = 0;
    // Send message
    if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
        BridgeStatus = Bridge->WriteMsgCAN(pCanTxMsg, pDataTx, size);
        if (BridgeStatus != Brg_StatusT::BRG_NO_ERR) {
            Console::WriteLine("CAN Write Message error (Tx ID: 0x{0})", pCanTxMsg->ID.ToString("X")); // TODO: Throw exception
        }
    }
    // Receive message
    if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
        uint16_t dataSize;
        int retry = 100;
        while ((retry > 0) && (msgNb == 0))
        {
            BridgeStatus = Bridge->GetRxMsgNbCAN(&msgNb);
            retry--;
            Sleep(1);
        }
        if (msgNb == 0) { // check if enough messages available
            BridgeStatus = Brg_StatusT::BRG_TARGET_CMD_TIMEOUT;
            Console::WriteLine("CAN Rx error (not enough msg available: 0/1)");// TODO: Throw exception
        }
        if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) { // read only 1 msg even if more available
            BridgeStatus = Bridge->GetRxMsgCAN(pCanRxMsg, 1, pDataRx, 8, &dataSize);
        }
        if (BridgeStatus != Brg_StatusT::BRG_NO_ERR) {
            Console::WriteLine("CAN Read Message error (Tx ID: 0x{0}, nb of Rx msg available: {1})", pCanTxMsg->ID.ToString("X"), (int)msgNb);// TODO: Throw exception
        }
        else {
            if (pCanRxMsg->Fifo != rxFifo) {
                Console::WriteLine("CAN Read Message FIFO error (Tx ID: 0x{0} in FIFO%d instead of {1})", pCanTxMsg->ID.ToString("X"), (int)pCanRxMsg->Fifo, (int)rxFifo);// TODO: Throw exception
                BridgeStatus = Brg_StatusT::BRG_VERIF_ERR;
            }
        }
    }
    // verif Rx = Tx
    if (BridgeStatus == Brg_StatusT::BRG_NO_ERR) {
        if ((pCanRxMsg->ID != pCanTxMsg->ID) || (pCanRxMsg->IDE != pCanTxMsg->IDE) || (pCanRxMsg->DLC != size) ||
            (pCanRxMsg->Overrun != CAN_RX_NO_OVERRUN)) {
            BridgeStatus = Brg_StatusT::BRG_CAN_ERR;
            Console::WriteLine("CAN ERROR ID Rx: 0x{0} Tx 0x{1}, IDE Rx {2} Tx {3}, DLC Rx {4} size Tx {5}", pCanRxMsg->ID.ToString("X"), pCanTxMsg->ID.ToString("X"), (int)pCanRxMsg->IDE, (int)pCanTxMsg->IDE, (int)pCanRxMsg->DLC, (int)size);// TODO: Throw exception
        }
        else {
            for (int i = 0; i < size; i++) {
                if (pDataRx[i] != pDataTx[i]) {
                    Console::WriteLine("CAN ERROR data[{0}] Rx: 0x{1} Tx 0x{2}", (int)i, pDataRx[i].ToString("X"), pDataTx[i].ToString("X"));// TODO: Throw exception
                    BridgeStatus = Brg_StatusT::BRG_VERIF_ERR;
                }
            }
        }
        if (BridgeStatus != Brg_StatusT::BRG_NO_ERR) {
            Console::WriteLine("CAN ERROR Read/Write verification");
        }
    }
    return BridgeStatus;
}
