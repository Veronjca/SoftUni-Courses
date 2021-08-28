using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int pointIndex = filePath.IndexOf(".");

            string extension = filePath.Substring(index+1);

            int slashIndex = filePath.LastIndexOf("\\");

            StringBuilder name = new StringBuilder();

            for (int i = slashIndex+1; i < pointIndex; i++)
            {
                name.Append(filePath[i]);
            }

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
            
        }
    }
}
