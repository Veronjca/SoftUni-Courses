using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            
            int[] bottomRow = new int[];

            int counter = 0;
            int[] topRow = new int[];

            for (int i = 0; i < topRow.Length / 2; i++)
            {
                 
                topRow[i] = numbers[i];

               
                
            }

            
        }
    }
}
