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
    public class CanWrapperTests
    {
        [TestMethod]
        public void CANLoopBackTest()
        {
            STLinkBridgeWrapperCsharp wrapper = new STLinkBridgeWrapperCsharp();
            var devices = new List<DeviceInfo>();
            STLinkIf_StatusT linkStatus = wrapper.EnumerateDevices(out devices);


            DeviceInfo selectedDevice = devices.FirstOrDefault();
            if (selectedDevice == null)
                throw new Exception("No STLink device found");

            Brg_StatusT bridgeStatus = wrapper.OpenBridge(selectedDevice);
            wrapper.CanMessageReceived += Wrapper_CanMessageReceived;
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
            wrapper.CanInit(125000, true);
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
            wrapper.StartTransmission(100);
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);


            var canMessage = GenerateSimpleCanMessageType();
            var signal1 = canMessage.Signals[0];
            var signal2 = canMessage.Signals[1];
            var signal3 = canMessage.Signals[2];
            signal1.WriteValue = -1.3;
            signal2.WriteValue =  1.4;
            signal3.WriteValue =  5;
            signal1.CalculateBitMask();
            signal2.CalculateBitMask();
            signal3.CalculateBitMask();

            wrapper.canMessageTypes = new SortedList<uint, CanMessageType>();
            wrapper.canMessageTypes.Add((uint)canMessage.ID, canMessage);

            wrapper.CanWrite(canMessage);
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

            System.Threading.Thread.Sleep(1000);

            Assert.IsTrue(signal1.DataPoints.Count > 0);
            Assert.IsTrue(signal2.DataPoints.Count > 0);
            Assert.IsTrue(signal3.DataPoints.Count > 0);

            wrapper.StopTransmission();
        }

        private void Wrapper_CanMessageReceived(object sender, CanMessageReceivedEventArgs e)
        {
        }

        public CanMessageType GenerateSimpleCanMessageType()
        {
            return new CanMessageType
            {
                ID = 305419896,
                DLC = 8,
                Flags = MESSAGE.EXT,
                Name = "TestMessage1",
                Signals = new List<CanSignalType>
                {
                    new CanSignalType
                    {
                        StartBit = 0,
                        Length = 8,
                        Offset = 50,
                        ScaleFactor = 10,
                        Name = "TestSignal1",
                    },
                    new CanSignalType
                    {
                        StartBit = 8,
                        Length = 16,
                        Offset = 50,
                        ScaleFactor = 10,
                        Name = "TestSignal2",
                    },
                    new CanSignalType
                    {
                        StartBit = 24,
                        Length = 8,
                        Offset = 50,
                        ScaleFactor = 10,
                        Name = "TestSignal3",
                    },
                }
            };
        }
    }
}
