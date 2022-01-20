using PingPong.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.UI.ConsoleApp.Common
{
    public class ConsoleOutputString : IOutput<string>
    {
        public void SentOut(string data)
        {
            Console.WriteLine(data);
        }
    }
}
