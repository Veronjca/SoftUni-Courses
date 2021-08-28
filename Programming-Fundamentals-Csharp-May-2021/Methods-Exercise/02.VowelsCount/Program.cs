using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowels = GetVowelsCount(input);

            Console.WriteLine(vowels);
        }

        private static int GetVowelsCount(string input)
        {
            int vowelsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 97 || input[i] == 101 || input[i] == 105 || input[i] == 111 || input[i] == 117 || input[i] == 65 || input[i] == 69 || input[i] == 73 || input[i] == 79 || input[i] == 85)
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }
    }
}
