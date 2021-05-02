using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDefinitions
{
    public interface ICanNetworkConnection
    {
        void WriteMessage(CanMessage message);
        //IEnumerable<CanMessage> ReadMessages();

        void OpenConnection(int baudrate);
        void CloseConnection();

        event EventHandler<CanConnectionChangedEventArgs> CanConnectionStatusChanged;
        event EventHandler<CanMessageReceivedEventArgs> CanMessageReceived;

        bool CanConnectionRunning { get; }
    }

    public class CanConnectionChangedEventArgs : EventArgs
    {
        public bool CanConnectionRunning { get; set; }
    }

    public class CanMessageReceivedEventArgs : EventArgs
    {
        public List<CanMessage> ReceivedMessages { get; set; } = new List<CanMessage>();
        public bool BufferOverrunDetected { get; set; } = false;
    }
}
