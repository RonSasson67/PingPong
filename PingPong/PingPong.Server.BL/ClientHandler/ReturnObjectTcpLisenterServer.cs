using PingPong.Server.BL.ClientHandler.Abstract;
using PingPong.UI.Common;
using System;
using System.Net.Sockets;

namespace PingPong.Server.BL.ClientHandler
{
    public class ReturnObjectTcpLisenterServer : IClientHandler
    {
        private IOutput<string> _output;
  
        public int MassageSize { get; set; } = 1024;

        public ReturnObjectTcpLisenterServer(IOutput<string> output)
        {
            _output = output;
        }

        public void RunHandler(object Handler)
        {
            TcpClient client = (TcpClient)Handler;

            NetworkStream stream = client.GetStream();

            int i;
            byte[] bytes = new Byte[MassageSize];

            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    String data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    _output.SentOut($"From {client.ToString()} received: {data}");

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    _output.SentOut($"Sent: {data}");
                }
            }
            catch (Exception)
            {
                _output.SentOut($"Close {client.ToString()}");
                client.Close();
            }                    
        }
    }
}
