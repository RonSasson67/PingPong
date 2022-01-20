using PingPong.Client.BL.ClientConnect.Abstract;
using PingPong.Client.BL.ServerHandler.Abstract;
using PingPong.UI.Common;
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

        public SocketConnect(IServerHandler clientHandler, string ip, int port, IInput<string> input, IOutput<string> output, ProtocolType protocol, AddressFamily family) : base(clientHandler, ip, port, input, output)
        {
            Protocol = protocol;
            Family = family;
        }

        public override void RunClient()
        {

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(_ip), _port);

            Socket sender = new Socket(Family,
                SocketType.Stream, Protocol);

            try
            {
                sender.Connect(remoteEP);
                _output.SentOut($"Socket connected to {sender.RemoteEndPoint.ToString()}");

                _serverHandler.RunHandler(sender);
            }
            catch (ArgumentNullException ane)
            {
               _output.SentOut($"ArgumentNullException : {ane.Message}");
            }
            catch (SocketException se)
            {
                _output.SentOut($"SocketException : {se.Message}");
            }
            catch (Exception e)
            {
                _output.SentOut($"Unexpected exception : {e.Message}");
            }
            
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}

