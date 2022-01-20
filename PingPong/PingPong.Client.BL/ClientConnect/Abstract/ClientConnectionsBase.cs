using PingPong.Client.BL.ServerHandler.Abstract;
using PingPong.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Client.BL.ClientConnect.Abstract
{
    public abstract class ClientConnectionsBase
    {
        protected IServerHandler _serverHandler;
        protected string _ip;
        protected int _port;
        protected IInput<string> _input;
        protected IOutput<string> _output;

        public ClientConnectionsBase(IServerHandler clientHandler, string ip, int port, IInput<string> input, IOutput<string> output)
        {
            _serverHandler = clientHandler;
            _ip = ip;
            _port = port;
            _input = input;
            _output = output;
        }

        public abstract void RunClient();
    }
}
