using System;

namespace NameGame
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();

            while (name != "Stop")
            {
                int number = int.Parse(Console.ReadLine());
                name = Console.ReadLine();
            }


        }
    }
}
