using PingPong.UI.Common;
using System;

namespace PingPong.UI.ConsoleApp.Common
{
    public class ConsoleInputInt : IInput<int>
    {
        public int getInput()
        {
            do
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("try input number...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (true);
        }
    }
}
