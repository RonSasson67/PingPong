using System;

namespace PingPong.UI.Server.Tcp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BootstrapTcpServer bootstrapTcpSocketServer = new BootstrapTcpServer();
            var server = bootstrapTcpSocketServer.BootStrapTcpLisent("127.0.0.1", 666);
;           server.RunServer();
        }
    }
}
