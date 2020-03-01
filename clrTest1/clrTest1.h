#pragma once
#include "stdafx.h"
#include "Resource.h"
#include "stlink_interface.h"

using namespace System;

namespace clrTest1 
{
	public ref class Class1
	{
    private:
        STLinkInterface* sTLinkInterface;
    public:
        float mul(float first, float second)
        {
            return first * second;
        }
        Class1();
        ~Class1();



        //STLinkInterface::STLinkInterface(STLink_EnumStlinkInterfaceT IfId = STLINK_BRIDGE);
        //STLinkInterface::virtual                        ~STLinkInterface(void);

        //STLink_EnumStlinkInterfaceT     GetIfId(void) const { return m_ifId; }
        //STLinkIf_StatusT                LoadStlinkLibrary(const char *pPathOfProcess);
        bool                            IsLibraryLoaded();
        //STLinkIf_StatusT                EnumDevices(uint32_t *pNumDevices, bool bClearList);
        //STLinkIf_StatusT                GetDeviceInfo2(int StlinkInstId, STLink_DeviceInfo2T *pInfo, uint32_t InfoSize);
        //STLinkIf_StatusT                OpenDevice(int StlinkInstId, uint32_t StlinkIdTcp, bool bOpenExclusive, void **pHandle);
        //STLinkIf_StatusT                OpenDevice(const char *pSerialNumber, bool bStrict, uint32_t StlinkIdTcp, bool bOpenExclusive, void **pHandle);
        //STLinkIf_StatusT                CloseDevice(void *pHandle, uint32_t StlinkIdTcp);
        //STLinkIf_StatusT                SendCommand(void *pHandle, uint32_t StlinkIdTcp, STLink_DeviceRequestT *pDevReq, const uint16_t UsbTimeoutMs);
        String^                    GetPathOfProcess(void);
	};
}
