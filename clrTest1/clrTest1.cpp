#include "stdafx.h"

#include "clrTest1.h"
//#include "bridge.h"

using namespace clrTest1;

Class1::Class1()
{
    this->sTLinkInterface = new STLinkInterface(STLINK_BRIDGE);
}

Class1::~Class1()
{
    delete sTLinkInterface;
}

//STLink_EnumStlinkInterfaceT     Class1::GetIfId(void) const { return m_ifId; }
STLinkIf_StatusT Class1::LoadStlinkLibrary(String^ PathOfProcess)
{
	const char* path = StringToCharPtr(PathOfProcess);
	return sTLinkInterface->LoadStlinkLibrary(path);
}
bool Class1::IsLibraryLoaded()
{
    return sTLinkInterface->IsLibraryLoaded();
}

STLinkIf_StatusT Class1::EnumDevices([Out] uint32_t% NumDevices, bool bClearList)
{
	uint32_t *pNumDevices = new uint32_t(0);
	STLinkIf_StatusT  status = sTLinkInterface->EnumDevices(pNumDevices, bClearList);

	NumDevices = (*pNumDevices);
	delete pNumDevices;
	return status;
}

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

const char * Class1::StringToCharPtr(String ^ s)
{
	using namespace Runtime::InteropServices;
	const char* chars = (const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();
	return chars;
}