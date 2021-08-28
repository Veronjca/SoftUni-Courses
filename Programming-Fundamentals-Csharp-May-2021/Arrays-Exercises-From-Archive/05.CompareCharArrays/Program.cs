using System;
using System.Linq;

namespace _05.CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            char[] secondArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            if (firstArray.Length == secondArray.Length)
            {
                if (firstArray[0] < secondArray[0])
                {

                    Console.WriteLine(firstArray);
                    Console.WriteLine(secondArray);
                }
                else if (firstArray[0] > secondArray[0])
                {
                    Console.WriteLine(secondArray);
                    Console.WriteLine(firstArray);

                }
            }
           

            //if (firstArray.Length == secondArray.Length)
            //{
            //    int counter = 0;

            //    for (int i = 0; i < firstArray.Length; i++)
            //    {
            //        if (firstArray[i] == secondArray[i])
            //        {
            //            counter++;

            //        }
            //        else if (firstArray[i] < secondArray[i])
            //        {
            //            first = String.Join(" ", firstArray); 
            //            second = String.Join(" ", secondArray);
            //        }
            //        else if (secondArray[i] < firstArray[i])
            //        {
            //            first = String.Join(" ", secondArray);
            //            second = String.Join(" ", firstArray);
            //        }

            //    }

            //    if (counter == firstArray.Length)
            //    {
            //        first = String.Join(" ", firstArray);
            //        second = String.Join(" ", secondArray);
            //    }
            //}

            //if (firstArray.Length < secondArray.Length)
            //{
            //    int counter = 0;

            //    for (int i = 0; i < firstArray.Length; i++)
            //    {
            //        if (firstArray[i] == secondArray[i])
            //        {
            //            counter++;

            //        }
            //        else if (firstArray[i] < secondArray[i])
            //        {
            //            first = String.Join(" ", firstArray);
            //            second = String.Join(" ", secondArray);
            //        }
            //        else if (secondArray[i] < firstArray[i])
            //        {
            //            first = String.Join(" ", secondArray);
            //            second = String.Join(" ", firstArray);
            //        }

            //    }

            //    if (counter == firstArray.Length)
            //    {
            //        first = String.Join(" ", firstArray);
            //        second = String.Join(" ", secondArray);
            //    }
            //}

            //if (firstArray.Length > secondArray.Length)
            //{
            //    int counter = 0;

            //    for (int i = 0; i < secondArray.Length; i++)
            //    {
            //        if (firstArray[i] == secondArray[i])
            //        {
            //            counter++;

            //        }
            //        else if (firstArray[i] < secondArray[i])
            //        {
            //            first = String.Join(" ", firstArray);
            //            second = String.Join(" ", secondArray);
            //        }
            //        else if (secondArray[i] < firstArray[i])
            //        {
            //            first = String.Join(" ", secondArray);
            //            second = String.Join(" ", firstArray);
            //        }

            //    }

            //    if (counter == secondArray.Length)
            //    {
            //        first = String.Join(" ", secondArray);
            //        second = String.Join(" ", firstArray);
            //    }
            //}

            //first = first.Replace(" ", String.Empty);
            //second = second.Replace(" ", String.Empty);

            //Console.WriteLine(first);
            //Console.WriteLine(second);


          
        }
    }
}
