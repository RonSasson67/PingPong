using PingPong.Client.BL.RunClient;
using PingPong.Client.BL.RunClient.Abstract;
using PingPong.Client.BL.ServerHandler;
using PingPong.UI.ConsoleApp.Common;

namespace ClientTcpConsoleApp
{
    public class BootstrapTcpClient
    {
        public RunClientBase BootStrapSocket()
        {
            ConsoleInputInt inputInt = new ConsoleInputInt();
            ConsoleInputString inputString = new ConsoleInputString();
            ConsoleOutputString output = new ConsoleOutputString();

            SendBackClient sendBackClient = new SendBackClient(inputString, output);
;
            return new TcpSocketClinetRun(sendBackClient, output, inputInt, inputString);
        }

        public RunClientBase BootStrapTcpClient(object objectToSend)
        {
            ConsoleInputInt inputInt = new ConsoleInputInt();
            ConsoleInputString inputString = new ConsoleInputString();
            ConsoleOutputString output = new ConsoleOutputString();

            ReturnObjectTcpLisenterClient client = new ReturnObjectTcpLisenterClient(objectToSend, output);

            return new TcpClientRun(client, output, inputString, inputInt, objectToSend);
        }
    }
}
