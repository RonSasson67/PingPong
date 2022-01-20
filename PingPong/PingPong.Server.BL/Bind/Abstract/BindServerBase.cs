using PingPong.Server.BL.ClientHandler.Abstract;

namespace PingPong.Server.BL.Bind.Abstract
{
    public abstract class BindServerBase
    {
        protected IClientHandler _clientHandler;
        protected string _ip;
        protected int _port;

        public BindServerBase(IClientHandler clientHandler, string ip, int port)
        {
            _clientHandler = clientHandler;
            _ip = ip;
            _port = port;
        }

        public abstract void BindServer();
    }
}
