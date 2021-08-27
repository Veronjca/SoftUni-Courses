using System;

namespace CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int index = 0; index < text.Length; index++)
            {
                Console.WriteLine(text[index]);
            }
        }
    }
}
