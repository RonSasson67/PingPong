using PingPong.Client.BL.RunClient.Abstract;
using PingPong.Client.BL.RunClient;
using PingPong.Client.BL.ServerHandler;
using System;
using System.Collections.Generic;
using System.Text;
using PingPong.UI.ConsoleApp.Common;

namespace ClientTcpConsoleApp
{
    public class BootstrapTcpSocketClient
    {
        public RunClientBase BootStrap()
        {
            ConsoleInputInt inputInt = new ConsoleInputInt();
            ConsoleInputString inputString = new ConsoleInputString();
            ConsoleOutputString output = new ConsoleOutputString();

            SendBackClient sendBackClient = new SendBackClient(inputString, output);
;
            return new TcpClinetRun(sendBackClient, output, inputInt);
        }
    }
}
