using System;

namespace WhileLoppLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            while (name != "Stop")
            {
                Console.WriteLine(name);
                name = Console.ReadLine();
            }
        }
    }
}
