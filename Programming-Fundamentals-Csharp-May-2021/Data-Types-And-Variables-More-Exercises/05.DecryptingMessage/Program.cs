using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            string message = "";

            for (int i = 1; i <= lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                message += (char)(letter + key);

            }

            Console.Write(message);
        }
    }
}
