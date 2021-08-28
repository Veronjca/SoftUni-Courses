using System;
using System.Linq;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            // съкратено решение

            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            if (numbers.All(x => x > 0))
            {
                Console.WriteLine("positive");
            }
            else if (numbers.Any(x => x == 0))
            {
                Console.WriteLine("zero");
            }
            else if (numbers.Any(x => x < 0))
            {
                Console.WriteLine("negative");

            }

            // дълго решение

            //int firstNumber = int.Parse(Console.ReadLine());
            //int secondNumber = int.Parse(Console.ReadLine());
            //int thirdNumber = int.Parse(Console.ReadLine());

            //Result(firstNumber, secondNumber, thirdNumber);

            //private static void Result(int firstNumber, int secondNumber, int thirdNumber)
            //{

            //    if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            //    {
            //        Console.WriteLine("zero");
            //        return;
            //    }

            //    if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0)
            //    {
            //        Console.WriteLine("positive");
            //        return;
            //    }

            //    int counter = 0;

            //    if (firstNumber < 0)
            //    {
            //        counter++;
            //    }
            //    if (secondNumber < 0)
            //    {
            //        counter++;
            //    }
            //    if (thirdNumber < 0)
            //    {
            //        counter++;
            //    }

            //    if (counter < 2 || counter > 2)
            //    {
            //        Console.WriteLine("negative");
            //    }
            //    else
            //    {
            //        Console.WriteLine("positive");
            //    }

            //}
        }
    }
}
