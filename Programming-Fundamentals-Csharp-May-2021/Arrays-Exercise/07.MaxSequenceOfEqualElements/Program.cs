using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int longestSequence = 1;
            int sequenceOf = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int currentNum = numbers[i];

                int currentSequence = 1;


                for (int j = i; j < numbers.Length - 1; j++)
                {
                    if (currentNum == numbers[j + 1])
                    {
                        currentSequence++;
                    }
                    else
                    {
                        break;
                    }

                }

                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    sequenceOf = numbers[i];
                }

            }



            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write(sequenceOf + " ");
            }

        }
    }
}
