using System;
using System.Linq;

namespace _07.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondArray = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int sum = 0;

            //Решение №2
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
                else
                {
                    sum += firstArray[i];
                }

            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");

            //Решение №2
            for (int i = 0; i < firstArray.Length; i++)
            {

                int firstNumber = firstArray[i];

                for (int j = 0; j < secondArray.Length; j++)
                {
                    int secondNumber = secondArray[j + i];

                    if (firstNumber == secondNumber)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Arrays are not identical. Found difference at {j + i} index");
                        return;
                    }
                }


                sum += firstNumber;

            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
