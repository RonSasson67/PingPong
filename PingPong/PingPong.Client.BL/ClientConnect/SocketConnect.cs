using PingPong.Client.BL.ClientConnect.Abstract;
using PingPong.Client.BL.ServerHandler.Abstract;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Client.BL.ClientConnect
{
    public class SocketConnect : ClientConnectionsBase
    {
        public ProtocolType Protocol { get; set; }
        public AddressFamily Family { get; set; }

        public int MassageSize { get; set; } = 1024;

        public SocketConnect(ProtocolType protocol, AddressFamily family, IServerHandler clientHandler, int ip, int port) : base(clientHandler, ip, port)
        {
            Protocol = protocol;
            Family = family;
        }

        public override void RunClient()
        {

            IPEndPoint remoteEP = new IPEndPoint(_ip, _port);

            Socket sender = new Socket(Family,
                SocketType.Stream, Protocol);

            byte[] bytes = new byte[MassageSize];
            try
            {
                sender.Connect(remoteEP);
                _output.SentOut($"Socket connected to {sender.RemoteEndPoint.ToString()}");

                _serverHandler.RunHandler(sender);
            }
            catch (ArgumentNullException ane)
            {
               _output.SentOut($"ArgumentNullException : {ane.ToString()}");
            }
            catch (SocketException se)
            {
                _output.SentOut($"SocketException : {se.ToString()}");
            }
            catch (Exception e)
            {
                _output.SentOut($"Unexpected exception : {e.ToString()}");
            }
            
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}

