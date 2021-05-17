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

        public STLinkBridgeWrapper() : base()
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
                //CanMessageReceived?.Invoke(this, canMessageReceivedEventArgs);
                //CanMessageReceived?.BeginInvoke(this, canMessageReceivedEventArgs, CanMessageReceivedEndAsyncEvent, null);
                foreach(EventHandler<CanMessageReceivedEventArgs> receiver in CanMessageReceived.GetInvocationList())
                {
                    receiver.BeginInvoke(this, canMessageReceivedEventArgs, CanMessageReceivedEndAsyncEvent, null);
                }
            }
        }

        public List<CanMessage> CanRead()
        {
            List<CanMessage> receivedMessages = new List<CanMessage>();
            bool OverrunDetected = false;
            Brg_StatusT status = base.CanReadLL(out receivedMessages, OverrunDetected);

            if (status == Brg_StatusT.BRG_USB_COMM_ERR || status == Brg_StatusT.BRG_CONNECT_ERR)
                this.CloseConnection(); // TODO: Consider allowing a few errors for increased robustness

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
            if (base.CanWriteLL(message) != Brg_StatusT.BRG_NO_ERR)
                this.CloseConnection(); // TODO: Consider allowing a few errors for increased robustness

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

        private void CanMessageReceivedEndAsyncEvent(IAsyncResult iar)
        {
            var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
            var invokedMethod = (EventHandler<CanMessageReceivedEventArgs>)ar.AsyncDelegate;

            try
            {
                invokedMethod.EndInvoke(iar);
            }
            catch
            {
                // Some kind of logging system would be nice for situations like this
                // Handle any exceptions that were thrown by the invoked method
                Console.WriteLine("An event listener went kaboom!");
            }
        }
    }
}
