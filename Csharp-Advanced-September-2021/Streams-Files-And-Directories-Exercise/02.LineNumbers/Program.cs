using System;
using System.Collections.Generic;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
      
            string[] text = File.ReadAllLines("text.txt");
            List<string> temp = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                int numOfLetters = 0;
                int numOfPunctuactionMarks = 0;

                for (int j = 0; j < text[i].Length; j++)
                {
                    if (char.IsLetter(text[i][j]))
                    {
                        numOfLetters++;
                    }
                    else if (char.IsPunctuation(text[i][j]))
                    {
                        numOfPunctuactionMarks++;
                    }
                }                
                temp.Add($"Line {i+1}: {text[i]}({numOfLetters})({numOfPunctuactionMarks})");
            }
            File.WriteAllLines("output.txt", temp);
        }
    }
}
