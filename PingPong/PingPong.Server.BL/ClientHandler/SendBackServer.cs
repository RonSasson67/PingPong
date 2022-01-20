using PingPong.Server.BL.ClientHandler.Abstract;
using System;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Server.BL.ClientHandler
{
    public class SendBackServer : IClientHandler
    {
        public int MassageSize { get; set; } = 1024;
        public string EndchatWord { get; set; } = "<EOF>";


        public void RunHandler(object Handler)
        {
            Socket socket = (Socket)Handler;
            byte[] bytes = new Byte[MassageSize];
    
            while (true)
            {
                int bytesRec = socket.Receive(bytes);
                string data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                if (data.IndexOf(EndchatWord) > -1)
                {
                    data.Remove(data.IndexOf(EndchatWord), EndchatWord.Length);
                    socket.Send(Encoding.ASCII.GetBytes(data));
                    break;
                }

                socket.Send(Encoding.ASCII.GetBytes(data));
            }

            CloseClient(socket);
        }

        private void CloseClient(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
