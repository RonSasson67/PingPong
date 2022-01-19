using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.UI.Common
{
    public interface IOutput<T>
    {
        void SentOut(T data);
    }
}
