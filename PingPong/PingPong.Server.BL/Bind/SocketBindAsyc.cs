using PingPong.Server.BL.Bind.Abstract;
using PingPong.Server.BL.ClientHandler.Abstract;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Bind
{
    public class SocketBindAsyc : BindServerBase
    {
        public ProtocolType Protocol { get; set; }
        public AddressFamily Family { get; set; } 
        public int MaxLisent { get; set; } = 10;
        public SocketBindAsyc(AddressFamily family, ProtocolType protocol, IClientHandler clientHandler, string ip, int port) : base(clientHandler, ip, port)
        {
            Protocol = protocol;
            Family = family;
        }

        public override void BindServer()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(_ip), _port);

            Socket listener = new Socket(Family,  
                SocketType.Stream, Protocol);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(MaxLisent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Accept(listener);
        }

        private void Accept(Socket listener)
        {
            while (true)
            {
                Socket handler = listener.Accept();

                Task.Run(() => _clientHandler.RunHandler(handler));
            }
        }

    }
}
