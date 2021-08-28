using System;
using System.Linq;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    text = text.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
