using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                encryptedText.Append((char)((char)(text[i]) + 3));
            }

            Console.WriteLine(encryptedText);
        }
    }
}
