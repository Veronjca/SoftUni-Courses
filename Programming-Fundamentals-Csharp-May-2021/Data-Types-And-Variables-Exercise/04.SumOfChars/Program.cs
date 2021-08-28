using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                int letterToNumber = letter;
                sum += letterToNumber;
                
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
