using PingPong.Server.BL.ClientHandler.Abstract;

namespace PingPong.Server.BL.Bind.Abstract
{
    abstract class BindServerBase
    {
        protected IClientHandler _clientHandler;
        protected int _ip;
        protected int _port;

        public BindServerBase(IClientHandler clientHandler, int ip, int port)
        {
            _clientHandler = clientHandler;
            _ip = ip;
            _port = port;
        }

        public abstract void BindServer();
    }
}
