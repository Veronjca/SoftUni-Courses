using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            Reversed(number);
        }

        private static void Reversed(string number)
        {

            while (number != "END")
            {
                string reversed = "";

                for (int i = number.Length - 1; i >= 0; i--)
                {
                    reversed += number[i];
                }

                isEven(number, reversed);

                number = Console.ReadLine();

            }

        }

        private static void isEven(string number, string reversed)
        {
            if (reversed == number)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
