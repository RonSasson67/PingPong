using PingPong.Client.BL.ClientConnect;
using PingPong.Client.BL.RunClient.Abstract;
using PingPong.Client.BL.ServerHandler.Abstract;
using PingPong.UI.Common;
using System.Net.Sockets;

namespace PingPong.Client.BL.RunClient
{
    public class TcpClinetRun : RunClientBase
    {
        IInput<int> _inputInt;
        IInput<string> _inputString;
        IOutput<string> output;

        public TcpClinetRun(IServerHandler handler, IOutput<string> output, IInput<int> inputInt, IInput<string> inputString) : base(handler)
        {
            this.output = output;
            _inputInt = inputInt;
            _inputString = inputString;
        }

        public override void RunClient()
        {
            output.SentOut("Input ip(x.x.x.x):");
            string ip = _inputString.getInput();
            output.SentOut("Input port:");
            int port = _inputInt.getInput();

            var socket = new SocketConnect(ProtocolType.Tcp, AddressFamily.InterNetwork, _handler, ip, port);
            socket.RunClient();
        }
    }
}
