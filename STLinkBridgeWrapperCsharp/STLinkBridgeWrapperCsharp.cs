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
        public List<CanBridgeMessageRx> ReceivedMessages { get; set; } = new List<CanBridgeMessageRx>();
        public bool BufferOverrunDetected { get; set; } = false;
    }

    public class STLinkBridgeWrapper : STLinkBridgeWrapperCpp
    {
        public delegate void CanMessageReceivedHandler(object sender, CanMessageReceivedEventArgs e);
        public event CanMessageReceivedHandler CanMessageReceived;
        protected Timer CanPollingTimer = new Timer();
        
        public STLinkBridgeWrapper()
        {
            CanPollingTimer.Elapsed += CanPollingTimer_Elapsed;

        }
        public Brg_StatusT StartTransmission(Nullable<double> pollrate)
        {
            base.StartTransmission();
            if (pollrate != null)
            {
                CanPollingTimer.Interval = (double)pollrate;
                CanPollingTimer.Start();
            }
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
            var receivedMessages = CanRead();

            CanMessageReceivedEventArgs canMessageReceivedEventArgs = new CanMessageReceivedEventArgs();

            // Check for overrun
            foreach (var message in receivedMessages)
            {
                if (message.OverrunBuffer || message.Fifo) 
                {
                    CanPollingTimer.Interval /= 1.2; // Polling was too slow. Poll faster
                }
                canMessageReceivedEventArgs.BufferOverrunDetected = true;
            }

            if (receivedMessages.Count > 0)
            {
                canMessageReceivedEventArgs.ReceivedMessages = receivedMessages;
                CanMessageReceived?.BeginInvoke(this, new CanMessageReceivedEventArgs(), CanMessageReceivedEndAsyncEvent, null);
            }
        }

        public List<CanBridgeMessageRx> CanRead()
        {
            List<CanBridgeMessageRx> receivedMessages = new List<CanBridgeMessageRx>(); ;
            base.CanReadLL(out receivedMessages);
            return receivedMessages;
        }

        //public Brg_StatusT CanWrite(CanMessageType canMessageType)
        //{
        //    CanBridgeMessageTx message = new CanBridgeMessageTx
        //    {
        //        ID = (uint)canMessageType.ID,
        //        IdExtended = canMessageType.Flags == MESSAGE.EXT,
        //        RTR = false,
        //        DLC = (byte)canMessageType.DLC,
        //    };
        //
        //    UInt64 payload = 0;
        //    foreach(var signal in canMessageType.Signals)
        //    {
        //        // Scale and offset value according to signal secification
        //        double tranformedValue = signal.WriteValue * signal.ScaleFactor;
        //        tranformedValue += signal.Offset;
        //
        //        // Cast to integer. The scaling should have been chosen such that this casting is okay.
        //        var bits = (UInt64)tranformedValue;
        //
        //        // Get the bits, trim and shift according to specification
        //        bits <<= signal.StartBit;
        //        bits &= signal.BitMask; // Trim
        //
        //        // Add to payload
        //        payload |= bits;
        //    }
        //    message.data = payload;
        //
        //    return base.CanWriteLL(message);
        //}

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
