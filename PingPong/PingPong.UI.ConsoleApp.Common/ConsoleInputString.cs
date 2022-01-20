using PingPong.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.UI.ConsoleApp.Common
{
    public class ConsoleInputString : IInput<string>
    {
        public string getInput()
        {
            return Console.ReadLine();
        }
    }
}
