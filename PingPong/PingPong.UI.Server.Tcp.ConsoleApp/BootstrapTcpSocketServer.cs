﻿using PingPong.Server.BL;
using PingPong.Server.BL.Bind;
using PingPong.Server.BL.ClientHandler;
using System.Net.Sockets;

namespace ClientTcpConsoleApp
{
    public class BootstrapTcpSocketServer
    {
        public ServerRun BootStrap(int ip, int port)
        {     
            SendBackServer sendBackClient = new SendBackServer();
            SocketBindAsyc socketBindAsyc = new SocketBindAsyc(AddressFamily.InterNetwork, ProtocolType.Tcp, sendBackClient, ip, port);
;
            return new ServerRun(socketBindAsyc);
        }
    }
}
