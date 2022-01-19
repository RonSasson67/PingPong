using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Client.BL.ServerHandler.Abstract
{
    public interface IServerHandler
    {
        void RunHandler(object Handler);
    }
}
