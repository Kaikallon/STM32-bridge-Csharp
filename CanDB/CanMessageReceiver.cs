using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDB
{
    class CanMessageReceiver
    {
        //public static void CanMessageReceivedCallback(object sender, STLinkBridgeWrapper.CanMessageReceivedEventArgs e)
        //{
        //    foreach (var canMessage in e.ReceivedMessages)
        //    {
        //        Type type;
        //        if (CanMessageMap.TryGetValue((int)canMessage.ID, out type))
        //        {
        //            CanMessage instance = (CanMessage)Activator.CreateInstance(type);
        //            instance.Data = canMessage.data;
        //            instance.SystemTimeStamp = DateTime.Now.Ticks;
        //            instance.NotifySubscribers();
        //        }
        //    }
        //}
    }
}
