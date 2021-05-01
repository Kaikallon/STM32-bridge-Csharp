using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDefinitions
{
    interface ICanNetworkConnection
    {
        void WriteMessage(CanMessage message);
        IEnumerable<CanMessage> ReadMessages();

        void OpenConnection(int baudrate);
        void CloseConnection();

        event EventHandler CanTransmissionStatusChanged;
        event EventHandler<CanMessageReceivedEventArgs> CanMessageReceived;
    }
}
