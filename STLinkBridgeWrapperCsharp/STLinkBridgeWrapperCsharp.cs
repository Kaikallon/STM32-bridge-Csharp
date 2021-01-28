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

    public class STLinkBridgeWrapper : STLinkBridgeWrapperCpp
    {
        public delegate void CanMessageReceivedHandler(object sender, CanMessageReceivedEventArgs e);
        public event CanMessageReceivedHandler CanMessageReceived;
        protected Timer CanPollingTimer = new Timer();
        
        public SortedList<uint, CanMessageType> canMessageTypes;

        public STLinkBridgeWrapper()
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
            List<CanBridgeMessageRx> receivedMessages = new List<CanBridgeMessageRx>(); ;
            base.CanReadLL(out receivedMessages);

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
                    // TODO: Raise event maybe?
                }

                foreach (var signalType in canMessage.Signals)
                {
                    // TODO: Check if the bitmask has been calculated
                    // Isolate relevant bits using precalculated bitmask
                    //UInt64 bits = BitConverter.ToUInt64(message.data, 0);
                    UInt64 bits = message.data;
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

        public List<CanBridgeMessageRx> CanRead()
        {
            List<CanBridgeMessageRx> receivedMessages = new List<CanBridgeMessageRx>(); ;
            base.CanReadLL(out receivedMessages);
            return receivedMessages;
        }

        public Brg_StatusT CanWrite(CanMessageType canMessageType)
        {
            CanBridgeMessageTx message = new CanBridgeMessageTx
            {
                ID = (uint)canMessageType.ID,
                IdExtended = canMessageType.Flags == MESSAGE.EXT,
                RTR = false,
                DLC = (byte)canMessageType.DLC,
            };

            UInt64 payload = 0;
            foreach(var signal in canMessageType.Signals)
            {
                // Scale and offset value according to signal secification
                double tranformedValue = signal.WriteValue * signal.ScaleFactor;
                tranformedValue += signal.Offset;

                // Cast to integer. The scaling should have been chosen such that this casting is okay.
                var bits = (UInt64)tranformedValue;

                // Get the bits, trim and shift according to specification
                bits <<= signal.StartBit;
                bits &= signal.BitMask; // Trim

                // Add to payload
                payload |= bits;
            }
            message.data = payload;

            return base.CanWriteLL(message);
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
