using PingPong.Client.BL.ServerHandler.Abstract;
using System;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PingPong.UI.Common;

namespace PingPong.Client.BL.ServerHandler
{
    internal class ReturnObjectTcpLisenterClient : IServerHandler
    {
        private object _objectToPass;
        protected IOutput<string> _output;

        public ReturnObjectTcpLisenterClient(object objectToPass, IOutput<string> output)
        {
            _objectToPass = objectToPass;
            _output = output;
        }

        public void RunHandler(object Handler)
        {
            NetworkStream stream = (NetworkStream)Handler;

            var msg = SerializationObject(_objectToPass);
            stream.Write(msg, 0, msg.Length);

            Byte[] data = new Byte[256];

            Int32 bytes = stream.Read(data, 0, data.Length);     

            object reciveObject = deseialazationObject(data);
            _output.SentOut(reciveObject.ToString());
        }

        private byte[] SerializationObject(object objectToSerailaization)
        {
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, objectToSerailaization);
            return fs.ToArray();
        }

        private object deseialazationObject(byte[] bytes)
        {
            BinaryFormatter formattor = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(bytes);
            object obj = formattor.Deserialize(ms);
            return obj;
        }
    }
}
