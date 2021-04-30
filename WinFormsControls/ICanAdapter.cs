﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsControls
{
    public interface ICanAdapter
    {
        void Broadcast(CanDefinitions.CanMessage message);
        event EventHandler<STLinkBridgeWrapper.CanMessageReceivedEventArgs> CanMessageReceived;


    }
}