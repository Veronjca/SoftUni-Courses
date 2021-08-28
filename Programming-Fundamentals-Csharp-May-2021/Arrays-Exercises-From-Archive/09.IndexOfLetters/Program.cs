using System;

namespace _09.IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[26];
            int counter = 98;

            for (int i = 1; i <= alphabet.Length - 1; i++)
            {
                alphabet[0] = (char)97;
                alphabet[i] = (char)(counter++);
            }

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (input[i] == alphabet[j])
                    {
                        Console.WriteLine($"{input[i]} -> {j}");
                    }
                }
            }


        }
    }
}
