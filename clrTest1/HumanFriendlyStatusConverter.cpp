#include "stdafx.h"
#include "HumanFriendlyStatusConverter.h"
using namespace STLinkCLRWrapper;

HumanFriendlyStatusConverter::HumanFriendlyStatusConverter()
{
}

String^ HumanFriendlyStatusConverter::STLinkIf_StatusToString(STLinkIf_StatusT status)
{
	switch (status)
	{
	case STLinkIf_StatusT::NO_ERR:
		return "OK, no error.";
	case STLinkIf_StatusT::CONNECT_ERR:
		return "USB Connection error";
	case STLinkIf_StatusT::DLL_ERR:
		return "USB DLL error";
	case STLinkIf_StatusT::USB_COMM_ERR:
		return "USB Communication error";
	case STLinkIf_StatusT::PARAM_ERR:
		return "Wrong parameters error";
	case STLinkIf_StatusT::NO_STLINK:
		return "STLink device not opened error";
	case STLinkIf_StatusT::NOT_SUPPORTED:
		return "Parameter error";
	case STLinkIf_StatusT::PERMISSION_ERR:
		return "STLink device already in use by another program error";
	case STLinkIf_StatusT::ENUM_ERR:
		return "USB enumeration error";
	case STLinkIf_StatusT::GET_INFO_ERR:
		return "Error getting STLink device information";
	case STLinkIf_StatusT::SN_NOT_FOUND:
		return "Required STLink serial number not found error";
	case STLinkIf_StatusT::CLOSE_ERR:
		return "Error during device Close";
	default:
		return "";

	}
}