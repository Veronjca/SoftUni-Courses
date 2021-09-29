using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Streams_Files_And_Directories_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader stream = new StreamReader("text.txt");
           
            List<string> lines = new List<string>();

            int counter = 0;
            while (!stream.EndOfStream)
            {
                string currentLine = stream.ReadLine();
                if (counter % 2 == 0)
                {
                    lines.Add(currentLine);
                }
                counter++;
            }

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (char.IsPunctuation(lines[i][j]))
                    {
                        lines[i] = lines[i].Replace(lines[i][j], '@');
                    }
                }

            }

            //StreamWriter writer = new StreamWriter("output.txt");
            foreach (var item in lines)
            {

                Console.WriteLine(String.Join(' ', item.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse()));
            }
        }
    }
}
