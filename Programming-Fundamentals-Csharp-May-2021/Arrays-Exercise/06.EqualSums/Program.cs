using System;
using System.Linq;
using System.Text;

namespace _06.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool flag = false;

            for (int i = 0; i < numbers.Length; i++)
            {               
               int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += numbers[j];
                }
                for (int k = numbers.Length - 1; k > i; k--)
                {
                    rightSum += numbers[k];
                }

                if (leftSum == rightSum)
                {
                    flag = true;
                    Console.WriteLine(i);

                }
            }

            if (!flag)
            {
                Console.WriteLine("no");
            }
      
        }
    }
}
