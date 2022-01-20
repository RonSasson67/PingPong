using PingPong.Client.BL.ServerHandler.Abstract;

namespace PingPong.Client.BL.RunClient.Abstract
{
    public abstract class RunClientBase
    {
        protected IServerHandler _handler;

        protected RunClientBase(IServerHandler handler)
        {
            _handler = handler;
        }

        public abstract void RunClient();
    }
}
