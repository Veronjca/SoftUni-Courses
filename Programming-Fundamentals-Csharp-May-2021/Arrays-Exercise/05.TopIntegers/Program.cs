using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                bool flag = false;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    flag = false;

                    if (currentNumber > numbers[j])
                    {
                        flag = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (flag)
                {
                    Console.Write(currentNumber + " ");
                }
            }

            Console.WriteLine(numbers[numbers.Length - 1]);
        }
    }
}
