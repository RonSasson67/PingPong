using PingPong.Client.BL.ClientConnect;
using PingPong.Client.BL.RunClient.Abstract;
using PingPong.Client.BL.ServerHandler.Abstract;
using PingPong.UI.Common;
using System.Net.Sockets;

namespace PingPong.Client.BL.RunClient
{
    internal class TcpClinetRun : RunClientBase
    {
        IInput<int> _input;
        IOutput<string> output;

        public TcpClinetRun(IServerHandler handler, IOutput<string> output, IInput<int> input) : base(handler)
        {
            this.output = output;
            _input = input;
        }

        public override void RunClient()
        {
            output.SentOut("Input ip:");
            int ip = _input.getInput();
            output.SentOut("Input ip:");
            int port = _input.getInput();

            var socket = new SocketConnect(ProtocolType.Tcp, AddressFamily.InterNetwork, _handler, ip, port);
            socket.RunClient();
        }
    }
}
