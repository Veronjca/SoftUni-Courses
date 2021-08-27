using System;

namespace LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char beginning = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char notIncluded = char.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = beginning; i <= end; i++)
            {
                for (int j = beginning; j <= end; j++)
                {
                    for (int k = beginning; k <= end; k++)
                    {
                        if ((char)i != notIncluded && (char)j != notIncluded && (char)k != notIncluded)
                        {
                            counter++;
                            Console.Write($"{(char)i}{(char)j}{(char)k} ");

                        }
                    }
                }
            }

            Console.Write(counter);
        }
    }
}
