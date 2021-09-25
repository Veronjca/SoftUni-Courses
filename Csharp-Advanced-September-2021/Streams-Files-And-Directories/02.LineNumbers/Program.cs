using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("input.txt");
            using StreamWriter sw = new StreamWriter("output.txt");

            int counter = 1;
            while (!sr.EndOfStream)
            {
                string currentLine = sr.ReadLine();

                sw.WriteLine($"{counter}. {currentLine}");

                counter++;
            }
        }
    }
}
