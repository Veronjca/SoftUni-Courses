using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());

            CharactersInRange(firstCharacter, secondCharacter);
        }

        private static void CharactersInRange(char firstCharacter, char secondCharacter)
        {
            
            if (firstCharacter > secondCharacter)
            {
                for (int i = secondCharacter+1; i < firstCharacter; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = firstCharacter + 1; i < secondCharacter; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
