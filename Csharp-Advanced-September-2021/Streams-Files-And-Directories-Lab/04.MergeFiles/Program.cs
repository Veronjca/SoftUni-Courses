using System;
using System.Collections.Generic;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = File.ReadAllText("input.txt").ToCharArray();
            char[] input2 = File.ReadAllText("input2.txt").ToCharArray();

            List<string> output = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                output.Add(input[i].ToString());
                output.Add(input2[i].ToString());
            }
            File.WriteAllLines("output.txt", output);
        }
    }
}
