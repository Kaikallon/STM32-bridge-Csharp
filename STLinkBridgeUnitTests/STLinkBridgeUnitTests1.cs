using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STLinkBridgeWrapper;
using System.Linq;
using System.Diagnostics;
using CanDB;

namespace STLinkBridgeUnitTests
{
    [TestClass]
    public class STLinkBridgeUnitTests1
    {
        [TestMethod]
        public void CANLoopBackTest()
        {
            Wrapper wrapper = new Wrapper();
            var devices = new List<DeviceInfo>();
            STLinkIf_StatusT linkStatus = wrapper.EnumerateDevices(out devices);


            DeviceInfo selectedDevice = devices.FirstOrDefault();
            if (selectedDevice == null)
                throw new Exception("No STLink device found");

            Brg_StatusT bridgeStatus = wrapper.OpenBridge(selectedDevice);
            bridgeStatus = wrapper.CanTest();

        }
    }
}
