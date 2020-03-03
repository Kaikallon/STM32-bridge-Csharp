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
        m_pBrg->BindErrLog(&g_ErrLog);
#endif
    }
    else
    {
        // TODO: Throw error
    }
}

Wrapper::~Wrapper()
{
	delete sTLinkInterface;
	sTLinkInterface = NULL;

	delete Bridge; // TODO: Consider NULL-check
	Bridge = NULL;

	if (deviceInfo != NULL)
	{
		delete deviceInfo;
		deviceInfo = NULL;
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

const char * Wrapper::StringToCharPtr(String ^ s)
{
    using namespace Runtime::InteropServices;
    const char* chars = (const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();
    return chars;
}