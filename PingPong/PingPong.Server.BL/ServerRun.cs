﻿using PingPong.Server.BL.Bind.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

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
