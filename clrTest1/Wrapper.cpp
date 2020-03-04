/******************************************************************************************************************
FILENAME :
	Wrapper.cpp
DESCRIPTION :
	Provides a set of functions that wrap the STLink Bridge API for use in a .NET environment.
PUBLIC FUNCTIONS :
AUTHOR(s) :
	Alexander Andersson
START DATE : 2020-03-02
*******************************************************************************************************************
		   &&&&&&&&&&&&&&&&.                &&&&&&&&&&&&&&&&                      (@@@@@@@@@
		  &&&&&&&&&&&&&&&&&                &&&&&&&&&&&&&&&&                      @@@@@@@@@@@@#
		 #&&&&&&&&&&&&&&&&                &&&&&&&&&&&&&&&&                      @@@@@@@@@@@@@@@
		 &&&&&&&&&&&&&&&&                &&&&&&&&&&&&&&&&                     @@@@@@@@@@@@@@@@@@
						,,,,,,,,,,,,,,,,                                     @@@@@@@@@@@@@@@@@@@@.
					   .,,,,,,,,,,,,,,,.                                    @@@@@@@@@@@@@@@@@@@@@@@
					   ,,,,,,,,,,,,,,,,                                    @@@@@@@@@@@@ @@@@@@@@@@@@
					  ,,,,,,,,,,,,,,,,                                    *@@@@@@@@@@@@  @@@@@@@@@@@@
					 ,,,,,,,,,,,,,,,,                                      @@@@@@@@@@@@   (@@@@@@@@@@@&
	&&&&&&&&&&&&&&&&                .,,,,,,,,,,,,,,,,                        @@@@@@@@@@     @@@@@@@@@@@@
   &&&&&&&&&&&&&&&&                 ,,,,,,,,,,,,,,,,                      ,//////            @@@@@@@@@@@@
  &&&&&&&&&&&&&&&&&                ,,,,,,,,,,,,,,,,                  @@@@@@@@@@@@@     @@@@@@@@@@@@@@@@ .@(
 %&&&&&&&&&&&&&&&&                ,,,,,,,,,,,,,,,,                .@@@@@@@@@@@@@@@@/   @@@@@@@@@@@@@@@@@@@@,
.&&&&&&&&&&&&&&&&                ,,,,,,,,,,,,,,,,.               @@@@@@@@@@@@@@@@@@@@  @@@@@@@@@@@@@@@@@@@@@@
				,,,,,,,,,,,,,,,,                                @@@@@@@@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@@@@@@@@@*
			   ,,,,,,,,,,,,,,,,.                              &@@@@@@@@@@@*                        %@@@@@@@@@@@@
			  .,,,,,,,,,,,,,,,,                              @@@@@@@@@@@@                            @@@@@@@@@@@@
			  ,,,,,,,,,,,,,,,,                              @@@@@@@@@@@@                              @@@@@@@@@@@@.
******************************************************************************************************************/

#include "stdafx.h"
#include "Wrapper.h"
using namespace System;
using namespace STLinkCLRWrapper;


Wrapper::Wrapper()
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
    if (BridgeStatus == BRG_NO_ERR)
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

Wrapper::~Wrapper()
{
	this->!Wrapper();
}

Wrapper::!Wrapper()
{
	delete deviceInfo;
	deviceInfo = NULL;

	// Disconnect
	if (Bridge != NULL)
	{
		Bridge->CloseBridge(COM_UNDEF_ALL);
		Bridge->CloseStlink();
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


Brg_StatusT Wrapper::InitBridge()
{

	return BridgeStatus;
}

STLinkIf_StatusT Wrapper::GetInterfaceStatus()
{
    return this->InterfaceStatus;
}

Brg_StatusT Wrapper::GetBridgeStatus()
{
    return this->BridgeStatus;
}

STLinkIf_StatusT Wrapper::EnumerateDevices([Out] List<DeviceInfo>% results)
{
    uint32_t numDevices;
    // Safety check
    if (InterfaceStatus != STLinkIf_StatusT::NO_ERR)
    {
        Console::WriteLine("STLinkUSBDriver library (dll) issue");
        return InterfaceStatus;
    }

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
        DeviceInfo devInfo;
        devInfo.DeviceUsed = tempDeviceInfo.DeviceUsed;
        devInfo.EnumUniqueId = gcnew String(tempDeviceInfo.EnumUniqueId);
        devInfo.ProductId = tempDeviceInfo.ProductId;
        devInfo.StLinkUsbId = tempDeviceInfo.DeviceUsed;
        devInfo.VendorId = tempDeviceInfo.VendorId;
        results.Add(devInfo);
        
        //String^ temp = String::Format("Bridge {0:d} PID: 0X{1:04hx} SN:{2:s}", (int)i, (unsigned short)tempDeviceInfo.ProductId, gcnew String(tempDeviceInfo.EnumUniqueId));
        //Console::WriteLine(temp);

        //if ((firstDevNotInUse == -1) && (tempDeviceInfo->DeviceUsed == false))
        //{
        //    firstDevNotInUse = i;
        //    memcpy(m_serialNumber, &(tempDeviceInfo->EnumUniqueId), SERIAL_NUM_STR_MAX_LEN);
        //    Console::WriteLine(String::Format(" SELECTED BRIDGE Stlink SN:%s", gcnew String(m_serialNumber)));
        //}
    }

    BridgeStatus = Brg::ConvSTLinkIfToBrgStatus(InterfaceStatus);
    return InterfaceStatus;
}
Brg_StatusT      Wrapper::OpenBridge(String^ device)
{
    if (Bridge == NULL)
    {
        // TODO: Consider throwing exception
        return BridgeStatus;
    }

    // Check for errors
    if (BridgeStatus != BRG_NO_ERR)
    {
        return BridgeStatus;
    }

    // Open the STLink connection
    Bridge->SetOpenModeExclusive(true);

    BridgeStatus = Bridge->OpenStlink(deviceInfo->EnumUniqueId, true);

    if (BridgeStatus == BRG_NOT_SUPPORTED)
    {
        BridgeStatus = Brg::ConvSTLinkIfToBrgStatus(sTLinkInterface->GetDeviceInfo2(0, deviceInfo, sizeof(*deviceInfo)));
        Console::WriteLine(String::Format("BRIDGE not supported PID: 0X%04hx SN:%s", (unsigned short)deviceInfo->ProductId, gcnew String(deviceInfo->EnumUniqueId)));
    }

    if (BridgeStatus == BRG_OLD_FIRMWARE_WARNING)
    {
        BridgeStatus = BRG_NO_ERR;
    }
    return BridgeStatus;
}



Brg_StatusT      Wrapper::TestVoltage([Out] float% result) 
{
    if (Bridge == NULL)
    {
        // TODO: Consider throwing exception
        return BridgeStatus;
    }
    // Test Voltage command
    if (BridgeStatus == BRG_NO_ERR)
    {
        float voltage = 0;
        // T_VCC pin must be connected to target voltage on debug connector
        BridgeStatus = Bridge->GetTargetVoltage(&voltage);
        result = voltage;
        if ((BridgeStatus != BRG_NO_ERR) || (voltage == 0)) {
            //printf("BRIDGE get voltage error (check if T_VCC pin is connected to target voltage on debug connector)\n");
            Console::WriteLine(String::Format("BRIDGE get voltage error (check if T_VCC pin is connected to target voltage on debug connector)"));
        }
        else {
            Console::WriteLine(String::Format("BRIDGE get voltage: %f V", (double)voltage));
        }
    }

    return BridgeStatus;
}

Brg_StatusT Wrapper::GPIOInit()
{
	if (BridgeStatus == BRG_NO_ERR) 
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
			BridgeStatus = BRG_NOT_SUPPORTED;
		}

		// Set GPIO mode
		if (BridgeStatus == BRG_NO_ERR) 
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
			if (BridgeStatus != BRG_NO_ERR) 
			{
				Console::WriteLine(String::Format("Bridge Gpio init failed (mask=%d, gpio0: mode= %d, pull = %d, ...)\n",
					(int)gpioParams.GpioMask, (int)gpioConf[0].Mode, (int)gpioConf[0].Pull)); // TODO: Change enums to public enum class for better readability of error messages
			}
		}


	}
	return BridgeStatus;

}

Brg_StatusT Wrapper::GPIOWrite()
{
	Brg_GpioValT gpioReadVal[BRG_GPIO_MAX_NB] = { GPIO_RESET , GPIO_SET , GPIO_RESET , GPIO_SET };
	uint8_t gpioMask = BRG_GPIO_ALL;
	uint8_t gpioErrMsk;


	// Test GPIO
	if (BridgeStatus == BRG_NO_ERR)
	{
		BridgeStatus = Bridge->SetResetGPIO(gpioMask, &gpioReadVal[0], &gpioErrMsk);
		if ((BridgeStatus != BRG_NO_ERR) || (gpioErrMsk != 0))
		{
			Console::WriteLine("Bridge Read error");
		}
		else 
		{
			//// Verify all gpio read to 1 (input pull up)
			//for (int i = 0; i < BRG_GPIO_MAX_NB; i++)
			//{
			//	if (gpioReadVal[i] != GPIO_SET) 
			//	{
			//		BridgeStatus = BRG_VERIF_ERR;
			//		Console::WriteLine(" Bridge Read Verif error ( gpio %d != SET)", i);
			//	}
			//}
		}
	}

	if (BridgeStatus == BRG_NO_ERR)
	{
		Console::WriteLine("GPIO Test1 OK");
	}
	return BridgeStatus;
}

Brg_StatusT Wrapper::CanTest()
{
	Brg_StatusT brgStat = BRG_NO_ERR;
	uint32_t currFreqKHz = 0;
	uint8_t com = COM_CAN;
	uint32_t StlHClkKHz, comInputClkKHz;
	// Get the current bridge input Clk
	brgStat = m_pBrg->GetClk(com, &comInputClkKHz, &StlHClkKHz);
	printf("CAN input CLK: %d KHz, STLink HCLK: %d KHz \n", (int)comInputClkKHz, (int)StlHClkKHz);

	// EXAMPLE FOR CAN Initialization, Brg::InitCAN(), Brg::GetCANbaudratePrescal()

	Brg *m_pBrg;
	**********[Missing init steps] * *********
		Brg_StatusT brgStat = BRG_NO_ERR;
	Brg_CanInitT canParam;
	uint32_t prescal;
	uint32_t reqBaudrate = 125000; //125kbps
	uint32_t finalBaudrate = 0;

	// N=sync+prop+seg1+seg2= 1+2+7+6= 16, 125000 bps (-> prescal = 24 = (CanClk = 48MHz)/(16*125000))
	canParam.BitTimeConf.propSegInTq = 2;
	canParam.BitTimeConf.phaseSeg1InTq = 7;
	canParam.BitTimeConf.phaseSeg2InTq = 6;
	canParam.BitTimeConf.sjwInTq = 3;
	brgStat = m_pBrg->GetCANbaudratePrescal(&canParam.BitTimeConf, reqBaudrate, (uint32_t*)&prescal, (uint32_t*)&finalBaudrate);
	if (brgStat == BRG_COM_FREQ_MODIFIED) {
		printf("WARNING Bridge CAN init baudrate asked %d bps but applied %d bps \n", (int)reqBaudrate, (int)finalBaudrate);
	}
	else if (brgStat == BRG_COM_FREQ_NOT_SUPPORTED) {
		printf("ERROR Bridge CAN init baudrate %d bps not possible (invalid prescaler: %d) change Bit Time or baudrate settings. \n", (int)reqBaudrate, (int)prescal);
	}
	else if (brgStat == BRG_NO_ERR) {
		canParam.Prescaler = prescal;
		canParam.Mode = CAN_MODE_NORMAL;
		canParam.bIsTxfpEn = false;
		canParam.bIsRflmEn = false;
		canParam.bIsNartEn = false;
		canParam.bIsAwumEn = false;
		canParam.bIsAbomEn = false;
		brgStat = m_pBrg->InitCAN(&canParam, BRG_INIT_FULL);
	}

	// EXAMPLE FOR CAN loopback test, Brg::StartMsgReceptionCAN() Brg::InitFilterCAN() Brg::WriteMsgCAN() Brg::GetRxMsgNbCAN() Brg::GetRxMsgCAN()</B>\n

	Brg *m_pBrg;
	**********[Missing init steps] * *********
		// use init with canParam.Mode = CAN_MODE_LOOPBACK or connect a target that send back the received message

		Brg_StatusT brgStat = BRG_NO_ERR;
	uint8_t dataRx[8], dataTx[8];
	int i, nb;
	Brg_CanFilterConfT filterConf;
	Brg_CanRxMsgT canRxMsg;
	Brg_CanTxMsgT canTxMsg;
	uint8_t size = 0;
	uint16_t msgNb = 0;

	brgStat = m_pBrg->StartMsgReceptionCAN();
	if (brgStat != BRG_NO_ERR) {
		printf("CAN StartMsgReceptionCAN failed \n");
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
	if (brgStat == BRG_NO_ERR) {
		brgStat = m_pBrg->InitFilterCAN(&filterConf);
		if (brgStat != BRG_NO_ERR) {
			printf("CAN filter0 init failed \n");
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
	while ((brgStat == BRG_NO_ERR) && (nb < 255)) {

		for (i = 0; i < 8; i++) {
			dataRx[i] = 0;
			dataTx[i] = (uint8_t)(nb + i);
		}
		canRxMsg.DLC = 0;
		canTxMsg.DLC = 2; // unused in CAN_DATA_FRAME
		size = (uint8_t)(nb % 9); // try 0 to 8 DLC size

		if (nb == 200) { // do it only once
			// REINIT command with same settings must be transparent and  must not break filter configuration
			brgStat = m_pBrg->InitCAN(&canParam, BRG_REINIT);
		}
		if (brgStat == BRG_NO_ERR) {
			brgStat = CanMsgTxRxVerif(&canTxMsg, dataTx, &canRxMsg, dataRx, CAN_MSG_RX_FIFO0, size);
		}
		nb++;
	}
	if (brgStat == BRG_NO_ERR) {
		printf(" Loopback_test1 OK \n");
	}

	// send a message and verify it is received and that TX = Rx
	Brg_StatusT BrgTest::CanMsgTxRxVerif(Brg_CanTxMsgT *pCanTxMsg, uint8_t *pDataTx, Brg_CanRxMsgT *pCanRxMsg, uint8_t *pDataRx, Brg_CanRxFifoT rxFifo, uint8_t size)
	{
		Brg_StatusT brgStat = BRG_NO_ERR;
		uint16_t msgNb = 0;
		// Send message
		if (brgStat == BRG_NO_ERR) {
			brgStat = m_pBrg->WriteMsgCAN(pCanTxMsg, pDataTx, size);
			if (brgStat != BRG_NO_ERR) {
				printf("CAN Write Message error (Tx ID: 0x%08X)\n", (unsigned int)pCanTxMsg->ID);
			}
		}
		// Receive message
		if (brgStat == BRG_NO_ERR) {
			uint16_t dataSize;
			int retry = 100;
			while ((retry > 0) && (msgNb == 0)) {
				brgStat = m_pBrg->GetRxMsgNbCAN(&msgNb);
				retry--;
				Sleep(1);
			}
			if (msgNb == 0) { // check if enough messages available
				brgStat = BRG_TARGET_CMD_TIMEOUT;
				printf("CAN Rx error (not enough msg available: 0/1)\n");
			}
			if (brgStat == BRG_NO_ERR) { // read only 1 msg even if more available
				brgStat = m_pBrg->GetRxMsgCAN(pCanRxMsg, 1, pDataRx, 8, &dataSize);
			}
			if (brgStat != BRG_NO_ERR) {
				printf("CAN Read Message error (Tx ID: 0x%08X, nb of Rx msg available: %d)\n", (unsigned int)pCanTxMsg->ID, (int)msgNb);
			}
			else {
				if (pCanRxMsg->Fifo != rxFifo) {
					printf("CAN Read Message FIFO error (Tx ID: 0x%08X in FIFO%d instead of %d)\n", (unsigned int)pCanTxMsg->ID, (int)pCanRxMsg->Fifo, (int)rxFifo);
					brgStat = BRG_VERIF_ERR;
				}
			}
		}
		// verif Rx = Tx
		if (brgStat == BRG_NO_ERR) {
			if ((pCanRxMsg->ID != pCanTxMsg->ID) || (pCanRxMsg->IDE != pCanTxMsg->IDE) || (pCanRxMsg->DLC != size) ||
				(pCanRxMsg->Overrun != CAN_RX_NO_OVERRUN)) {
				brgStat = BRG_CAN_ERR;
				printf("CAN ERROR ID Rx: 0x%08X Tx 0x%08X, IDE Rx %d Tx %d, DLC Rx %d size Tx %d\n", (unsigned int)pCanRxMsg->ID, (unsigned int)pCanTxMsg->ID, (int)pCanRxMsg->IDE, (int)pCanTxMsg->IDE, (int)pCanRxMsg->DLC, (int)size);
			}
			else {
				for (int i = 0; i < size; i++) {
					if (pDataRx[i] != pDataTx[i]) {
						printf("CAN ERROR data[%d] Rx: 0x%02hX Tx 0x%02hX \n", (int)i, (unsigned short)(unsigned char)pDataRx[i], (unsigned short)(unsigned char)pDataTx[i]);
						brgStat = BRG_VERIF_ERR;
					}
				}
			}
			if (brgStat != BRG_NO_ERR) {
				printf("CAN ERROR Read/Write verification \n");
			}
		}
		return brgStat;
	}

}

const char * Wrapper::StringToCharPtr(String ^ s)
{
    using namespace Runtime::InteropServices;
    const char* chars = (const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();
    return chars;
}