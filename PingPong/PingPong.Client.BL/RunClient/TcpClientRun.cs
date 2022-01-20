using PingPong.Client.BL.ClientConnect;
using PingPong.Client.BL.RunClient.Abstract;
using PingPong.Client.BL.ServerHandler;
using PingPong.Client.BL.ServerHandler.Abstract;
using PingPong.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Client.BL.RunClient
{
    public class TcpClientRun : RunClientBase
    {
        private object _objectToPass;
        private IOutput<string> _output;
        private IInput<string> _inputString;
        private IInput<int> _inputInt;
        public TcpClientRun(IServerHandler handler) : base(handler)
        {
        }

        public override void RunClient()
        {
            _output.SentOut("Input ip(x.x.x.x):");
            string ip = _inputString.getInput();
            _output.SentOut("Input port:");
            int port = _inputInt.getInput();

            ReturnObjectTcpLisenterClient returnObjectTcpLisenterClient = new ReturnObjectTcpLisenterClient(_objectToPass, _output);

            new TcpClientConnect(returnObjectTcpLisenterClient, ip, port, _inputString, _output);
        }
    }
}
