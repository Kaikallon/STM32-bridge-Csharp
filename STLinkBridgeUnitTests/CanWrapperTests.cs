using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STLinkBridgeWrapper;
using System.Linq;
using System.Diagnostics;
using CanDefinitions;

namespace STLinkBridgeUnitTests
{
    [TestClass]
    public class CanWrapperTests
    {
        [TestMethod]
        public void CANLoopBackTest()
        {
            STLinkBridgeWrapper.STLinkBridgeWrapper wrapper = new STLinkBridgeWrapper.STLinkBridgeWrapper();
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
            wrapper.StartTransmission(null);
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

            var canMessage = GenerateSimpleCanMessageType();
            var signal1 = canMessage.Signals["TestSignal1"];
            var signal2 = canMessage.Signals["TestSignal2"];
            var signal3 = canMessage.Signals["TestSignal3"];

            signal1.CalculateBitMask();
            signal2.CalculateBitMask();
            signal3.CalculateBitMask();

            //wrapper.canMessageTypes = new SortedList<uint, CanMessageType>();
            //wrapper.canMessageTypes.Add((uint)canMessage.ID, canMessage);

            double value1 = -1.3;
            double value2 =  1.4;
            double value3 =  5;
            //var message = canMessage.GenerateCanMessageTx((signal1, value1), (signal2, value2), (signal3, value3));
            var message = new CanMessage();


            wrapper.CanWriteLL(message);
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

            System.Threading.Thread.Sleep(1000);

            var ReceivedMessages = wrapper.CanRead();
            var listOfMessages = new SortedList<uint, CanMessageType>();
            listOfMessages.Add((uint)canMessage.Id, canMessage);
            //var dataPoints = CanDB.CanDbcParser.ParseReceivedCanMessagesRx(ReceivedMessages, listOfMessages);

            //Assert.AreEqual(3, dataPoints.Count);

            //Assert.AreEqual(value1, dataPoints[0].data);
            //Assert.AreEqual(value2, dataPoints[1].data);
            //Assert.AreEqual(value3, dataPoints[2].data);


            wrapper.StopTransmission();
        }

        [TestMethod]
        public void CANListenTest()
        {
            STLinkBridgeWrapper.STLinkBridgeWrapper wrapper = new STLinkBridgeWrapper.STLinkBridgeWrapper();
            var devices = new List<DeviceInfo>();
            STLinkIf_StatusT linkStatus = wrapper.EnumerateDevices(out devices);


            DeviceInfo selectedDevice = devices.FirstOrDefault();
            if (selectedDevice == null)
                throw new Exception("No STLink device found");

            Brg_StatusT bridgeStatus = wrapper.OpenBridge(selectedDevice);
            wrapper.CanMessageReceived += Wrapper_CanMessageReceived;
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
            wrapper.CanInit(1000000, false);
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
            wrapper.StartTransmission(null);
            Assert.IsTrue(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
            
            System.Threading.Thread.Sleep(100);

            var ReceivedMessages = wrapper.CanRead();
            wrapper.StopTransmission();

            Debug.Assert(ReceivedMessages.Count < 0);
            
        }

        private void Wrapper_CanMessageReceived(object sender, CanMessageReceivedEventArgs e)
        {
            //var canMessage = GenerateSimpleCanMessageType();
            //var listOfMessages = new SortedList<uint, CanMessageType>();
            //listOfMessages.Add((uint)canMessage.ID, canMessage);

            //var dataPoints = CanDB.CanDB.ParseReceivedCanMessagesRx(e.ReceivedMessages, listOfMessages);

            //Assert.AreEqual(3, dataPoints.Count);
            //double value1 = -1.3;
            //double value2 = 1.4;
            //double value3 = 5;
            //Assert.AreEqual(value1, dataPoints[0].data);
            //Assert.AreEqual(value2, dataPoints[1].data);
            //Assert.AreEqual(value3, dataPoints[2].data);
        }

        public CanMessageType GenerateSimpleCanMessageType()
        {

            var signals = new List<CanSignalType>
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
            };
            return new CanMessageType(signals)
            {
                Id = 305419896,
                DLC = 4,
                //Flags = MESSAGE.EXT,
                Name = "TestMessage1",
            };
        }
    }
}
