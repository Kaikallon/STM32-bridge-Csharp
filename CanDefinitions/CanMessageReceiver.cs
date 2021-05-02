using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDefinitions
{
    class CanMessageReceiver
    {
        private readonly Dictionary<UInt32, Type> _canMessageMap;
        public Dictionary<UInt32, Type> CanMessageMap
        {
            get { return _canMessageMap; }
        }

        private CanMessageReceiver()
        {
            _canMessageMap = new Dictionary<UInt32, Type>();
        }

        public CanMessageReceiver(Dictionary<UInt32, Type> canMessageMap)
        {
            this._canMessageMap = canMessageMap;
        }

        public void CanMessageReceivedCallback(object sender, CanMessageReceivedEventArgs e)
        {
            foreach (var canMessage in e.ReceivedMessages)
            {
                Type type;
                if (!CanMessageMap.TryGetValue(canMessage.Id, out type))
                {
                    continue;
                }

                // Promote message to more specific type
                CanMessageExtended instance = (CanMessageExtended)Activator.CreateInstance(type);
                if (instance == null)
                {
                    // TODO: Consider throwing exception. If this happens it can mean one of two things:
                    // 1. The user has not populated the CanMessageExtendedMap
                    // 2. The database is incomplete or incorrectly generated
                    continue;
                }
                // Copy all data
                instance.SetFields(canMessage);
                instance.NotifySubscribers();
            }
        }
    }
}
