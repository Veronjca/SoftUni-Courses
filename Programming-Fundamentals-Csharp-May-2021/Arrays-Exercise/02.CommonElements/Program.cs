using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {

            // Нуубско решение
            string[] firstArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] secondArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            if (firstArray.Length > secondArray.Length)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    int commonWord = Array.IndexOf(secondArray, firstArray[i]);
                    if (commonWord != -1)
                    {
                        Console.Write(secondArray[commonWord] + " ");
                    }
                }
            }
            else
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    int commonWord = Array.IndexOf(firstArray, secondArray[i]);
                    if (commonWord != -1)
                    {
                        Console.Write(firstArray[commonWord] + " ");
                    }
                }
            }


            //// Оптимизирано решение 
            string[] firstArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] secondArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);



            for (int i = 0; i < firstArray.Length; i++)
            {
                int commonWord = Array.IndexOf(secondArray, firstArray[i]);
                if (commonWord != -1)
                {
                    Console.Write(firstArray[i] + " ");
                }
            }

            // Още по-оптимизирано решение 

            string[] result = secondArray.Intersect(secondArray).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }

    }
}
