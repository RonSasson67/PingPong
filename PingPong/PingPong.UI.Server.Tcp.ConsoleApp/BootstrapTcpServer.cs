using PingPong.Server.BL;
using PingPong.Server.BL.Bind;
using PingPong.Server.BL.ClientHandler;
using PingPong.UI.ConsoleApp.Common;
using System.Net.Sockets;

namespace PingPong.UI.Server.Tcp.ConsoleApp
{
    public class BootstrapTcpServer
    {
        public ServerRun BootStrapSocket(string ip, int port)
        {     
            SendBackServer sendBackClient = new SendBackServer();
            SocketBindAsyc socketBindAsyc = new SocketBindAsyc(AddressFamily.InterNetwork, ProtocolType.Tcp, sendBackClient, ip, port);
;
            return new ServerRun(socketBindAsyc);
        }

        public ServerRun BootStrapTcpLisent(string ip, int port)
        {
            var output = new ConsoleOutputString();
            ReturnObjectTcpLisenterServer returnObjectTcpLisenterServer = new ReturnObjectTcpLisenterServer(output);
            TcpListenerBindAsync tcpListenerBindAsync = new TcpListenerBindAsync(returnObjectTcpLisenterServer, ip, port, output);
;
            return new ServerRun(tcpListenerBindAsync);
        }

    }
}
