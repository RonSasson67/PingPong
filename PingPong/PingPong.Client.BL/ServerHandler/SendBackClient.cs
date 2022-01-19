using PingPong.Client.BL.ServerHandler.Abstract;
using PingPong.UI.Common;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Client.BL.ServerHandler
{
    class SendData : IServerHandler
    {
        protected IInput<string> _input;
        protected IOutput<string> _output;
        public string EndchatWord { get; set; } = "<EOF>";
        public int MassageSize { get; set; } = 1024;



        public void RunHandler(object Handler)
        {
            Socket sender = (Socket)Handler;
            byte[] bytes = new Byte[MassageSize];

            byte[] msg; 

            while (true)
            {
                string data = _input.getInput();
                msg = Encoding.ASCII.GetBytes(data);

                int bytesSent = sender.Send(msg);

                int bytesRec = sender.Receive(bytes);
                _output.SentOut($"Recive: {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");

                if (data.IndexOf(EndchatWord) > -1)
                {                  
                    break;
                }
            }                        
        }
    }
}
