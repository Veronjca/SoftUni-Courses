using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> digits = new List<string>();
            List<string> letters = new List<string>();
            List<string> other = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                bool isDigit = Char.IsDigit(input[i]);
                bool isLetter = Char.IsLetter(input[i]);

                if (isDigit)
                {
                    digits.Add(input[i].ToString());
                }
                else if (isLetter)
                {
                    letters.Add(input[i].ToString());
                }
                else
                {
                    other.Add(input[i].ToString());
                }
            }

            Console.WriteLine(String.Join("", digits));
            Console.WriteLine(String.Join("", letters));
            Console.WriteLine(String.Join("", other));
        }
    }
}
