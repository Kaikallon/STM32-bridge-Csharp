#pragma once
#include "stlink_interface.h"
#include "bridge.h"


namespace STLinkCLRWrapper
{
	public ref class Wrapper
	{
	private:
		STLinkInterface* sTLinkInterface = NULL;
		Brg* Bridge = NULL;
		STLink_DeviceInfo2T* DeviceInfo = NULL;
		Brg_StatusT BridgeStatus = BRG_NO_ERR;
		STLinkIf_StatusT InterfaceStatus = STLINKIF_NO_ERR;
	public:
		Wrapper();
		~Wrapper();

		STLinkIf_StatusT Init();
		Brg_StatusT InitBridge();
		//STLinkIf_StatusT GetInterfaceStatus();
		//Brg_StatusT GetBridgeStatus();
	};



}