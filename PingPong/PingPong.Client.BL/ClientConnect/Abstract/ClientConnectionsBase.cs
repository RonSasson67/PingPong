using PingPong.Client.BL.ServerHandler.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Client.BL.ClientConnect.Abstract
{
    abstract class ClientConnectionsBase
    {
        protected IServerHandler _serverHandler;
        protected int _ip;
        protected int _port;

        public ClientConnectionsBase(IServerHandler clientHandler, int ip, int port)
        {
            _serverHandler = clientHandler;
            _ip = ip;
            _port = port;
        }

        public abstract void RunClient();
    }
}
