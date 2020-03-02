#include "stdafx.h"
#include "Wrapper.h"
using namespace System;
using namespace STLinkCLRWrapper;


Wrapper::Wrapper()
{
	this->sTLinkInterface = new STLinkInterface(STLINK_BRIDGE);
}

Wrapper::~Wrapper()
{
	delete sTLinkInterface;
	sTLinkInterface = NULL;

	delete Bridge;
	Bridge = NULL;

	if (DeviceInfo != NULL)
	{
		delete DeviceInfo;
		DeviceInfo = NULL;
	}
}

STLinkIf_StatusT Wrapper::Init()
{
#ifdef WIN32 //Defined for applications for Win32 and Win64.
	char *pEndOfPrefix;
#endif
	uint32_t i, numDevices;
	int firstDevNotInUse = -1;
	char m_serialNumber[SERIAL_NUM_STR_MAX_LEN];

	// Note: cErrLog g_ErrLog; to be instanciated and initialized if used with USING_ERRORLOG

	// Create USB BRIDGE interface
	sTLinkInterface = new STLinkInterface(STLINK_BRIDGE);
#ifdef USING_ERRORLOG
	sTLinkInterface->BindErrLog(&g_ErrLog);
#endif


	// Load STLinkUSBDriver library
	InterfaceStatus = sTLinkInterface->LoadStlinkLibrary("");
	if (InterfaceStatus != STLINKIF_NO_ERR) 
	{
		Console::WriteLine("STLinkUSBDriver library (dll) issue");
		return InterfaceStatus;
	}

	InterfaceStatus = sTLinkInterface->EnumDevices(&numDevices, false);

	if (! ((InterfaceStatus == STLINKIF_NO_ERR) || (InterfaceStatus == STLINKIF_PERMISSION_ERR)) )
	{
		return InterfaceStatus;
	}

	Console::WriteLine(numDevices.ToString() + " BRIDGE device(s) found");
	// Choose the first STLink Bridge available
	for (i = 0; i < numDevices; i++)
	{
		InterfaceStatus = sTLinkInterface->GetDeviceInfo2(i, DeviceInfo, sizeof(*DeviceInfo));
		String^ temp = String::Format("Bridge {0:d} PID: 0X{1:04hx} SN:{2:s}", (int)i, (unsigned short)DeviceInfo->ProductId, gcnew String(DeviceInfo->EnumUniqueId));
		Console::WriteLine(temp);

		if ((firstDevNotInUse == -1) && (DeviceInfo->DeviceUsed == false))
		{
			firstDevNotInUse = i;
			memcpy(m_serialNumber, &(DeviceInfo->EnumUniqueId), SERIAL_NUM_STR_MAX_LEN);
			Console::WriteLine(String::Format(" SELECTED BRIDGE Stlink SN:%s", gcnew String(m_serialNumber)));
		}
	}

	BridgeStatus = Brg::ConvSTLinkIfToBrgStatus(InterfaceStatus);
	return InterfaceStatus;
}

Brg_StatusT Wrapper::InitBridge()
{
	if (BridgeStatus == BRG_NO_ERR) 
	{
		Bridge = new Brg(*sTLinkInterface);
#ifdef USING_ERRORLOG
		m_pBrg->BindErrLog(&g_ErrLog);
#endif
	}

	// Open the STLink connection
	if (BridgeStatus == BRG_NO_ERR) 
	{
		Bridge->SetOpenModeExclusive(true);

		BridgeStatus = Bridge->OpenStlink(DeviceInfo->EnumUniqueId, true);

		if (BridgeStatus == BRG_NOT_SUPPORTED)
		{
			BridgeStatus = Brg::ConvSTLinkIfToBrgStatus(sTLinkInterface->GetDeviceInfo2(0, DeviceInfo, sizeof(*DeviceInfo)));
			Console::WriteLine(String::Format("BRIDGE not supported PID: 0X%04hx SN:%s", (unsigned short)DeviceInfo->ProductId, gcnew String(DeviceInfo->EnumUniqueId)));
		}

		if (BridgeStatus == BRG_OLD_FIRMWARE_WARNING)
		{
			BridgeStatus = BRG_NO_ERR;
		}
	}
	// Test Voltage command
	if (BridgeStatus == BRG_NO_ERR) 
	{
		float voltage = 0;
		// T_VCC pin must be connected to target voltage on debug connector
		BridgeStatus = Bridge->GetTargetVoltage(&voltage);
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


