using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();

            text.Append(Console.ReadLine());
            

            for (int i = 1; i < text.Length; i++)
            {

                if (text[i-1] == text[i])
                {
                    text.Remove(i-1, 1);
                    i--;
                }
                
   
            }

            Console.WriteLine(text);

        }
    }
}
