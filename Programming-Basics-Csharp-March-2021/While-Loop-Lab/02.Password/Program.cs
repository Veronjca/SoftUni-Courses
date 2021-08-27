using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string intputPassword = "";

            while (password != intputPassword)
            {
                intputPassword = Console.ReadLine();
                if (password == intputPassword)
                {
                    Console.WriteLine($"Welcome {username}!");
                }
            }
        }
    }
}
