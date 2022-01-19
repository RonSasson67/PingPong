using PingPong.Server.BL.Bind.Abstract;

namespace PingPong.Server.BL
{
    class ServerRun
    {
        private BindServerBase _bind;

        public ServerRun(BindServerBase bind)
        {
            _bind = bind;
        }

        public void RunServer()
        {
            _bind.BindServer();
        }
    }
}
