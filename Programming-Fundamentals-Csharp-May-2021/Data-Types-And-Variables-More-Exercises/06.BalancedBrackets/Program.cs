using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            int openingBracket = 0;
            int closingBracket = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    openingBracket++;
                }
                if (input == ")")
                {
                    closingBracket++;
                }
                if (closingBracket > openingBracket)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }

            }

            if (openingBracket == closingBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}
