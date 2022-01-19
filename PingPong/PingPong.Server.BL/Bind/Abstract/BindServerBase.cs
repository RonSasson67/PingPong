using PingPong.Server.BL.ClientHandler.Abstract;

namespace PingPong.Server.BL.Bind.Abstract
{
    abstract class BindServerBase
    {
        protected ClientHandlerBase _clientHandler;
        protected int _ip;
        protected int _port;

        public BindServerBase(ClientHandlerBase clientHandler, int ip, int port)
        {
            _clientHandler = clientHandler;
            _ip = ip;
            _port = port;
        }

        public abstract void BindServer();
    }
}
