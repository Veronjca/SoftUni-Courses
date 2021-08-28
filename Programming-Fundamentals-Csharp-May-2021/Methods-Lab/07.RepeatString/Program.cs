using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int timesToRepeat = int.Parse(Console.ReadLine());

            string result = RepeatInput(input, timesToRepeat);
            Console.WriteLine(result);
        }

        private static string RepeatInput(string input, int timesToRepeat)
        {
            string result = "";
            for (int i = 0; i < timesToRepeat; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
