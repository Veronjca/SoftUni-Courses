using System;
using System.IO;

namespace Streams_Files_And_Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("input.txt");
            using StreamWriter sw = new StreamWriter("output.txt");

            int counter = 0;
            while (!sr.EndOfStream)
            {
                string currentLine = sr.ReadLine();
                if (counter % 2 != 0)
                {
                    sw.WriteLine(currentLine);
                }
                counter++;
            }
        }
    }
}
