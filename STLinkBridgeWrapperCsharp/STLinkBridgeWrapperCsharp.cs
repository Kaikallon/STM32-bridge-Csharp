using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CanDefinitions;

namespace STLinkBridgeWrapper
{
    public class STLinkBridgeWrapper : STLinkBridgeWrapperCpp, ICanNetworkConnection
    {
        public event EventHandler<CanConnectionChangedEventArgs> CanConnectionStatusChanged;
        public event EventHandler<CanMessageReceivedEventArgs> CanMessageReceived;
        protected Timer CanPollingTimer = new Timer();

        /// <summary>
        /// This property sets the target number of CAN messages in the buffer
        /// for each poll. If the number of messages in the buffer exceed this
        /// value, the poll rate will be increased.
        /// </summary>
        public int TargetMessageBufferUsage { get; set; } = 50;

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
            if (pollrate != null)
            {
                CanPollingTimer.Interval = (double)pollrate;
                CanPollingTimer.Start();
            }
            base.StartTransmission();
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
            List<CanMessage> receivedMessages = new List<CanMessage>();

            // Check for overrun
            // Note: Overrun detection does not seem to work because of an issue in the firmware of the STLink.
            // This code is kept for future possibilties of using it. 
            bool OverrunDetected = false;
            base.CanReadLL(out receivedMessages, OverrunDetected);

            if ((receivedMessages.Count > TargetMessageBufferUsage) || OverrunDetected)
                CanPollingTimer.Interval /= 1.05;

            if (receivedMessages.Count > 0)
            {
                CanMessageReceivedEventArgs canMessageReceivedEventArgs = new CanMessageReceivedEventArgs()
                {
                    BufferOverrunDetected = OverrunDetected,
                    ReceivedMessages = receivedMessages,
                };
                //CanMessageReceived?.BeginInvoke(this, canMessageReceivedEventArgs, CanMessageReceivedEndAsyncEvent, null);
                CanMessageReceived?.Invoke(this, canMessageReceivedEventArgs);
            }
        }

        public List<CanMessage> CanRead()
        {
            List<CanMessage> receivedMessages = new List<CanMessage>();
            bool OverrunDetected = false;
            base.CanReadLL(out receivedMessages, OverrunDetected);
            return receivedMessages;
        }

        protected override void NotifyTransmissionChanged()
        {
            CanConnectionStatusChanged?.Invoke(this, 
                new CanConnectionChangedEventArgs { CanConnectionRunning = this.TransmissionRunning});
        }

        public bool CanConnectionRunning
        {
            get { return TransmissionRunning; }
        }


        new public Brg_StatusT CloseBridge()
        {
            if (TransmissionRunning)
            {
                StopTransmission();
                System.Threading.Thread.Sleep(100); // TODO: This is a bit hacky, but seems to be enough to ensure that any ongoing polling is finished. Better would be to wait for a flag or something
            }
            base.CloseBridge();
            return this.BridgeStatus;
        }

        public void WriteMessage(CanMessage message)
        {
            if (!CanConnectionRunning)
            {
                // TODO: Do something? Throw exception, or just return quietly?
            }
            base.CanWriteLL(message);
        }

        public void OpenConnection(int baudrate)
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            StopTransmission();
            CloseBridge();
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
