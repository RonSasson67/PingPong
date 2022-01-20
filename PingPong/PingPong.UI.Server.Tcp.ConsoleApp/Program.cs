using System;

namespace PingPong.UI.Server.Tcp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BootstrapTcpSocketServer bootstrapTcpSocketServer = new BootstrapTcpSocketServer();
            var server = bootstrapTcpSocketServer.BootStrap("127.0.0.1", 666);
;           server.RunServer();
        }
    }
}
