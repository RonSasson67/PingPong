using PingPong.Client.BL.ClientConnect;
using PingPong.Client.BL.ServerHandler.Abstract;

namespace PingPong.Client.BL.RunClient.Abstract
{
    public abstract class RunClientBase
    {
        private IServerHandler _handler;

        protected RunClientBase(IServerHandler handler)
        {
            _handler = handler;
        }

        public abstract void RunClient();
    }
}
