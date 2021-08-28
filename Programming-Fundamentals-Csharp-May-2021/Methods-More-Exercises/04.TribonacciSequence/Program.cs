using System;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            uint num = uint.Parse(Console.ReadLine());

            if (num == 1)
            {
                Console.WriteLine(1);
            }
            else if (num == 2)
            {
                Console.WriteLine("1 " + "1");
            }
            else if (num == 3)
            {
                Console.WriteLine("1 " + "1 " + "2");
            }
            else
            {
                TribonacciSequence(num);
            }

            
        }

        private static void TribonacciSequence(uint num)
        {
            int[] numbers = new int[num];
            for (int i = 3; i < num; i++)
            {
                numbers[0] = 1;
                numbers[1] = 1;
                numbers[2] = 2;

                numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i-3];

            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
