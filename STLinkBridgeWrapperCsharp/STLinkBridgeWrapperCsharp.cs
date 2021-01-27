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
        protected Timer CanPollingTimer = new Timer();

        public SortedList<uint, CanMessageType> canMessageTypes;

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
            List<CanBridgeMessage> receivedMessages = new List<CanBridgeMessage>(); ;
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
                    CanPollingTimer.Interval /= 1.2; // Polling was too slow. Poll faster
                }

                foreach (var signalType in canMessage.Signals)
                {
                    // TODO: Check if the bitmask has been calculated
                    // Isolate relevant bits using precalculated bitmask
                    UInt64 bits = BitConverter.ToUInt64(message.data, 0);
                    bits &= signalType.BitMask;

                    // Shift back to original state according to specification
                    bits >>= signalType.StartBit;


                    double tempValue = (double)bits;

                    // Apply inverse transform to restore actual value
                    tempValue -= signalType.Offset;
                    tempValue /= signalType.ScaleFactor;
                    signalType.DataPoints.Add(new DataPoint
                    {
                        Ticks = message.TimeStamp,
                        CanTimeStamp = message.CanTimeStamp,
                        data = tempValue,
                    });
                }
            }

            if (receivedMessages.Count > 0)
            {
                CanMessageReceived?.BeginInvoke(this, new CanMessageReceivedEventArgs(), CanMessageReceivedEndAsyncEvent, null);
            }
        }

        public List<CanBridgeMessage> CanRead()
        {
            List<CanBridgeMessage> receivedMessages = new List<CanBridgeMessage>(); ;
            base.CanRead(out receivedMessages);
            return receivedMessages;
        }

        public Brg_StatusT CanWrite(CanMessageType canMessageType)
        {
            CanBridgeMessage message = new CanBridgeMessage
            {
                ID = (uint)canMessageType.ID,
                IdExtended = canMessageType.Flags == MESSAGE.EXT,
                RTR = false,                
            };

            UInt64 payload = 0;
            foreach(var signal in canMessageType.Signals)
            {
                // Scale and offset value according to signal secification
                double tranformedValue = signal.WriteValue * signal.ScaleFactor;
                tranformedValue += signal.Offset;

                // Cast to integer. The scaling should have been chosen such that this casting is okay.
                var intValue = (UInt64)tranformedValue;

                // Get the bits, trim and shift according to specification
                UInt64 bits = intValue;
                UInt64 trimmingMask = 0;
                for (int i = 0; i<signal.Length; i++)
                {
                    trimmingMask |= ((UInt64)1 << i);
                }
                bits &= trimmingMask; // Trim
                bits <<= signal.StartBit;

                // Add to payload
                payload |= bits;
            }
            message.data = BitConverter.GetBytes(payload);
            return base.CanWrite(message);
        }

        private void CanMessageReceivedEndAsyncEvent(IAsyncResult iar)
        {
            var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
            var invokedMethod = (CanMessageReceivedHandler)ar.AsyncDelegate;

            try
            {
                invokedMethod.EndInvoke(iar);
            }
            catch (Exception e)
            {
                // Handle any exceptions that were thrown by the invoked method
                // Console.WriteLine("An event listener went kaboom!");
                // TODO: Handle this?
            }
        }
    }
}
