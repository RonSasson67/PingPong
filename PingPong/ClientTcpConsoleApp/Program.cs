using PingPong.Client.BL.RunClient.Abstract;
using System;

namespace ClientTcpConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BootstrapTcpClient bootstrap = new BootstrapTcpClient();

            Console.WriteLine("input name:");
            string name = Console.ReadLine();
            Console.WriteLine("input age:");
            int age = int.Parse(Console.ReadLine());

            Person person = new Person(name, age);

            var client = bootstrap.BootStrapTcpClient(person);
            client.RunClient();
        }
    }
}
