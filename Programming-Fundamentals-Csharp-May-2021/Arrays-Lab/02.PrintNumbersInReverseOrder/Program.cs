using System;
using System.Linq;

namespace _02.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // Решение №1

            string[] numbers = new string[n];


            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Console.ReadLine();
            }

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbers[i]} ");
            }

            // Решение №2

            string[] numbers = new string[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Console.ReadLine();
            }

            string[] reversedNumbers = new string[numbers.Length];

            for (int i = 0; i < reversedNumbers.Length; i++)
            {
                reversedNumbers[i] = numbers[numbers.Length - 1 - i];
            }

            for (int i = 0; i < reversedNumbers.Length; i++)
            {
                Console.Write(reversedNumbers[i] + " ");
            }

            // Решение №3

            string[] numbers = new string[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[numbers.Length - 1 - i] = Console.ReadLine();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}");
            }

            // Решение №4

            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());

            }

            Array.Reverse(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

          

        }
    }
}
