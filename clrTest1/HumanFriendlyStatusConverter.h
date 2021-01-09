#pragma once
#include "stlink_interface.h"
#include "bridge.h"
using namespace System;

namespace STLinkCLRWrapper
{
	ref class HumanFriendlyStatusConverter
	{
	public:
		HumanFriendlyStatusConverter();
		static String^ STLinkIf_StatusToString(STLinkIf_StatusT status);
	};
}
