#include "stdafx.h"

#include "clrTest1.h"

using namespace clrTest1;

Class1::Class1()
{
    this->sTLinkInterface = new STLinkInterface();
}

Class1::~Class1()
{
    delete sTLinkInterface;
}

//STLink_EnumStlinkInterfaceT     Class1::GetIfId(void) const { return m_ifId; }
//STLinkIf_StatusT                Class1::LoadStlinkLibrary(const char *pPathOfProcess);
bool                            Class1::IsLibraryLoaded()
{
    return sTLinkInterface->IsLibraryLoaded();
}
//STLinkIf_StatusT                Class1::EnumDevices(uint32_t *pNumDevices, bool bClearList);
//STLinkIf_StatusT                Class1::GetDeviceInfo2(int StlinkInstId, STLink_DeviceInfo2T *pInfo, uint32_t InfoSize);
//STLinkIf_StatusT                Class1::OpenDevice(int StlinkInstId, uint32_t StlinkIdTcp, bool bOpenExclusive, void **pHandle);
//STLinkIf_StatusT                Class1::OpenDevice(const char *pSerialNumber, bool bStrict, uint32_t StlinkIdTcp, bool bOpenExclusive, void **pHandle);
//STLinkIf_StatusT                Class1::CloseDevice(void *pHandle, uint32_t StlinkIdTcp);
//STLinkIf_StatusT                Class1::SendCommand(void *pHandle, uint32_t StlinkIdTcp, STLink_DeviceRequestT *pDevReq, const uint16_t UsbTimeoutMs);
String^                    Class1::GetPathOfProcess(void)
{

    String^ temp = gcnew String(sTLinkInterface->GetPathOfProcess());

    return gcnew String(sTLinkInterface->GetPathOfProcess());
}