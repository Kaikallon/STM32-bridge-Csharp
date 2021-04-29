using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace STLinkBridgeWrapper
{
    public class CanMessageReceivedEventArgs : EventArgs
    {
        public List<CanBridgeMessageRx> ReceivedMessages { get; set; } = new List<CanBridgeMessageRx>();
        public bool BufferOverrunDetected { get; set; } = false;
    }

    public class STLinkBridgeWrapper : STLinkBridgeWrapperCpp
    {
        public event EventHandler CanTransmissionStatusChanged;
        public event EventHandler<CanMessageReceivedEventArgs> CanMessageReceived;
        protected Timer CanPollingTimer = new Timer();

        /// <summary>
        /// This property sets the target number of CAN messages in the buffer
        /// for each poll. If the number of messages in the buffer exceed this
        /// value, the poll rate will be increased.
        /// </summary>
        public int TargetMessageBufferUsage { get; set; } = 15;

        public double CurrentPollInterval
        {
            get { return CanPollingTimer.Interval; }
        }

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
            CanPollingTimer.Stop();
            base.StopTransmission();    
            return BridgeStatus;
        }

        private void CanPollingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var receivedMessages = CanRead();

            if (receivedMessages.Count > TargetMessageBufferUsage)
                CanPollingTimer.Interval /= 1.2;

            CanMessageReceivedEventArgs canMessageReceivedEventArgs = new CanMessageReceivedEventArgs();


            // Check for overrun
            // Note: This code deos not seem to work because of an issue in the firmware of the STLink.
            // This code is kept for future possibilties of using it. 
            foreach (var message in receivedMessages)
            {
                if (message.OverrunBuffer || message.Fifo) 
                {
                    CanPollingTimer.Interval /= 1.2; // Polling was too slow. Poll faster
                    canMessageReceivedEventArgs.BufferOverrunDetected = true;
                }
            }

            if (receivedMessages.Count > 0)
            {
                canMessageReceivedEventArgs.ReceivedMessages = receivedMessages;
                //CanMessageReceived?.BeginInvoke(this, canMessageReceivedEventArgs, CanMessageReceivedEndAsyncEvent, null);
                CanMessageReceived?.Invoke(this, canMessageReceivedEventArgs);
            }
        }

        public List<CanBridgeMessageRx> CanRead()
        {
            List<CanBridgeMessageRx> receivedMessages = new List<CanBridgeMessageRx>(); ;
            base.CanReadLL(out receivedMessages);
            return receivedMessages;
        }

        protected override void NotifyTransmissionChanged()
        {
            CanTransmissionStatusChanged?.Invoke(this, new EventArgs());
        }

        new public bool TransmissionRunning
        {
            get { return base.TransmissionRunning; }
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

        //private void CanMessageReceivedEndAsyncEvent(IAsyncResult iar)
        //{
        //    var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
        //    var invokedMethod = (CanMessageReceivedHandler)ar.AsyncDelegate;
        //
        //    try
        //    {
        //        invokedMethod.EndInvoke(iar);
        //    }
        //    catch (Exception e)
        //    {
        //        // Handle any exceptions that were thrown by the invoked method
        //        // Console.WriteLine("An event listener went kaboom!");
        //        // TODO: Handle this?
        //    }
        //}
    }
}
