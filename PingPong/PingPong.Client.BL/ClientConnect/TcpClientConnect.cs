using PingPong.Client.BL.ClientConnect.Abstract;
using PingPong.Client.BL.ServerHandler.Abstract;
using PingPong.UI.Common;
using System.Net.Sockets;

namespace PingPong.Client.BL.ClientConnect
{
    public class TcpClientConnect : ClientConnectionsBase
    {
        public TcpClientConnect(IServerHandler clientHandler, string ip, int port, IInput<string> input, IOutput<string> output) : base(clientHandler, ip, port, input, output)
        {
        }

        public override void RunClient()
        {
            TcpClient client = new TcpClient(_ip, _port);

            NetworkStream stream = client.GetStream();

            _serverHandler.RunHandler(stream);

            stream.Close();
            client.Close();
        }
    }
}
