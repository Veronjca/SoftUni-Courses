using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();

            text.Append(Console.ReadLine());


            int strength = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (strength > 0 && text[i] != 62)
                {
                    text.Remove(i, 1);
                    i--;
                    strength--;
                }
                else if (text[i] == 62 )
                {
                    strength += int.Parse(text[i + 1].ToString());
                }
           
            }

            Console.WriteLine(text);
        }
    }
}
