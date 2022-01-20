using PingPong.Server.BL.Bind.Abstract;
using PingPong.Server.BL.ClientHandler.Abstract;
using PingPong.UI.Common;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Bind
{
    public class TcpListenerBindAsync : BindServerBase
    {
        IOutput<string> _output;
        public TcpListenerBindAsync(IClientHandler clientHandler, string ip, int port, IOutput<string> output) : base(clientHandler, ip, port)
        {
            _output = output;
        }

        public override void BindServer()
        {
            IPAddress localAddr = IPAddress.Parse(_ip);

            TcpListener server = new TcpListener(localAddr, _port);

            server.Start();

            Appcept(server);
        }

        private void Appcept(TcpListener server)
        {
            while (true)
            {
                _output.SentOut("Waiting for a connection... ");
                
                TcpClient client = server.AcceptTcpClient();
                _output.SentOut("Connected!");
                Task.Run(() => _clientHandler.RunHandler(client));
            }
        }
    }
}
