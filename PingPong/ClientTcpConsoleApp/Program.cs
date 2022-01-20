using PingPong.Client.BL.RunClient.Abstract;
using System;

namespace ClientTcpConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BootstrapTcpSocketClient bootstrap = new BootstrapTcpSocketClient();
            var client = bootstrap.BootStrap();
            client.RunClient();
        }
    }
}
