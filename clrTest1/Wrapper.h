/******************************************************************************************************************
FILENAME :
	Wrapper.h
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
        uint32_t StLinkUsbId; ///< ST-LINK-SERVER Device cookie in little endian format, to use in STLINK_TCP_CMD_OPEN_DEVICE
        String^ EnumUniqueId; ///< Unique instance ID from system enumeration (equal to
                                                   ///< device Serial number in some cases, but not always ...)
        uint16_t VendorId;  ///< Vendor  ID from USB device descriptor (system enumeration)
        uint16_t ProductId; ///< Product ID from USB device descriptor (system enumeration)
        uint8_t DeviceUsed; ///< On windows, equal to 1 if device interface was already opened from 
                            ///< externally when enumerating or trying to open
        // NOTE: do not modify the existing fields in the structure. But for any evolution,
        // add a new field at the end in order to keep ascendant compatibility.
    };

    public ref class Wrapper
    {
    private:
        STLinkInterface* sTLinkInterface = NULL;
        Brg* Bridge = NULL;
        STLink_DeviceInfo2T* deviceInfo = NULL;
        Brg_StatusT BridgeStatus = BRG_NO_ERR;
        STLinkIf_StatusT InterfaceStatus = STLinkIf_StatusT::NO_ERR;
        const char* StringToCharPtr(String^ s);
    public:
        Wrapper();
        ~Wrapper();
		!Wrapper();


        Brg_StatusT InitBridge();
        STLinkIf_StatusT GetInterfaceStatus();
        Brg_StatusT GetBridgeStatus();

		STLinkIf_StatusT EnumerateDevices([Out] List<DeviceInfo^>^% results);
        Brg_StatusT      OpenBridge(String^ device);
        Brg_StatusT      TestVoltage([Out] float% result);
		Brg_StatusT		 GPIOInit();
		Brg_StatusT		 GPIOWrite();
		Brg_StatusT		 CanTest();
        
	};
}