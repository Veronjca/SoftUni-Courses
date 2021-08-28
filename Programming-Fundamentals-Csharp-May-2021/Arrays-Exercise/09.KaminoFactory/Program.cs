using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Moe решение 80/ 100
            int arrayLength = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int longestSequence = 1;
            int[] bestSample = new int[arrayLength];
            int index = 0;
            int sample = 0;

            int theNumberOfTheBestSample = 0;

            int bestSum = 0;


            while (command != "Clone them!")
            {
                int[] numbers = command
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                sample++;

                int sum = 0;

                sum = numbers.Sum();

                int sequence = 1;
                int currentIndex = 0;



                for (int i = 0; i < arrayLength - 1; i++)
                {
                    int currentNumber = numbers[i];

                    if (currentNumber == 1)
                    {
                        for (int j = i + 1; j < arrayLength; j++)
                        {
                            if (currentNumber == numbers[j])
                            {
                                sequence++;
                                currentIndex = i;

                            }
                            else
                            {
                                break;

                            }
                        }
                    }

                    if (sequence >= longestSequence && sample > 1 && currentIndex <= index)
                    {
                        if (sum > bestSum)
                        {
                            longestSequence = sequence;
                            bestSample = numbers;
                            theNumberOfTheBestSample = sample;
                            bestSum = sum;

                        }
                    }
                    if (currentIndex < index && sequence >= longestSequence)
                    {
                        longestSequence = sequence;
                        bestSample = numbers;
                        index = currentIndex;
                        theNumberOfTheBestSample = sample;
                        bestSum = sum;
                    }
                    else if (sequence > longestSequence)
                    {
                        longestSequence = sequence;
                        bestSample = numbers;
                        index = currentIndex;
                        theNumberOfTheBestSample = sample;
                        bestSum = sum;
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {theNumberOfTheBestSample} with sum: {bestSum}.");
            Console.Write(String.Join(" ", bestSample));


            // Решение на @mitowski 100/100 
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int bestSampleIndex = -1;

            int bestStartingIndex = int.MaxValue;
            int bestSequenceSum = -1;
            int bestSequenceCount = -1;

            int[] finalDna = new int[length];

            int inputCounter = 0;
            while (input != "Clone them!")
            {
                inputCounter++;
                int[] dna = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentSequence = 1;
                int currentSum = dna.Sum();

                int startingIndex = -1;
                int currentBestStartingIndex = -1;

                int currentMaxSeqience = 1;
                for (
                    int i = 1; i < dna.Length; i++)
                {
                    if (dna[i - 1] != dna[i])
                    {
                        currentSequence = 1;
                        startingIndex = i;
                    }
                    else
                    {
                        if (dna[i] == 1)
                        {
                            currentSequence++;

                        }
                    }

                    if (currentSequence > currentMaxSeqience)
                    {
                        currentMaxSeqience = currentSequence;
                        currentBestStartingIndex = startingIndex;
                    }
                }


                if (currentMaxSeqience >= bestSequenceCount)
                {
                    if (bestStartingIndex > currentBestStartingIndex)
                    {
                        bestSequenceCount = currentMaxSeqience;
                        bestStartingIndex = currentBestStartingIndex;
                        bestSampleIndex = inputCounter;
                        bestSequenceSum = currentSum;
                        finalDna = dna;
                    }
                    else if (bestStartingIndex == currentBestStartingIndex && currentSum > bestSequenceSum)
                    {
                        bestSequenceCount = currentMaxSeqience;
                        bestStartingIndex = currentBestStartingIndex;
                        bestSampleIndex = inputCounter;
                        bestSequenceSum = currentSum;
                        finalDna = dna;

                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ", finalDna));
        }
    }
}
