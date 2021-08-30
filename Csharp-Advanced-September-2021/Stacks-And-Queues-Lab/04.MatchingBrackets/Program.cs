using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int index = indexes.Pop();
                    Console.WriteLine(input.Substring(index, i - index + 1)); 
                }
            }
                

        }
            
    }
}
