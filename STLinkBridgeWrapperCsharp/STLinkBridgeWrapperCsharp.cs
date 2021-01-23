using CanDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace STLinkBridgeWrapper
{
    public class CanMessageReceivedEventArgs
    {
        
    }

    public class STLinkBridgeWrapperCsharp : Wrapper
    {
        public delegate void CanMessageReceivedHandler(object sender, CanMessageReceivedEventArgs e);
        public event CanMessageReceivedHandler CanMessageReceived;
        protected Timer CanPollingTimer;

        SortedList<uint, CanMessageType> canMessageTypes;

        public STLinkBridgeWrapperCsharp()
        {
            CanPollingTimer.Elapsed += CanPollingTimer_Elapsed;

        }
        public Brg_StatusT StartTransmission(double pollrate)
        {
            base.StartTransmission();
            CanPollingTimer.Interval = pollrate;
            CanPollingTimer.Start();
            return this.BridgeStatus;
        }

        public new Brg_StatusT StopTransmission()
        {
            base.StopTransmission();
            CanPollingTimer.Stop();
            return BridgeStatus;
        }

        private void CanPollingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // TODO: Perform polling
            List<CanBridgeMessage> receivedMessages;
            base.CanRead(out receivedMessages);

            foreach(var message in receivedMessages)
            {
                CanMessageType canMessage = canMessageTypes[message.ID];
                if (canMessage.DLC != message.DLC)
                {
                    throw new Exception("Error: DLC of received message did not match expected DLC from database."); // TODO: Handle more gracefully
                }
                if (message.OverrunBuffer || message.Fifo) 
                {
                    CanPollingTimer.Interval /= 1.2; // Polling too slow. Poll faster
                }

                BitArray bitArray = new BitArray(message.data);
                foreach (var signalType in canMessage.Signals)
                {
                    double tempValue = CanDB.CanDB.ConvertFromCanToDouble(signalType, bitArray);
                    signalType.DataPoints.Add(new DataPoint
                    {
                        Ticks = message.TimeStamp,
                        CanTimeStamp = message.CanTimeStamp,
                        data = tempValue,
                    });
                }
            }
        }
    } 
    
    
}
