using System;
using System.Linq;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleCharacters(input);

          
        }

        private static void MiddleCharacters(string input)
        {
            string middleChar = string.Empty;

            if (input.Length % 2 != 0)
            {
                middleChar = input[input.Length / 2].ToString();
            }
            else
            {
                middleChar = input[input.Length / 2 - 1].ToString();
                middleChar += input[input.Length / 2].ToString();

            }

            Console.WriteLine(middleChar);
        }
    }
}
