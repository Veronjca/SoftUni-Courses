using System;

namespace _07.Tuple
{
   public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
               
                if (i == 0)
                {                   
                    var current = new Tuple<string, string>($"{input[0]} {input[1]}", input[2]);
                    Console.WriteLine(current);
                }
                else if(i == 1)
                {
                    var current = new Tuple<string, int>(input[0] , int.Parse(input[1]));
                    Console.WriteLine(current);
                }
                else
                {
                   var current = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
                    Console.WriteLine(current);
                }               
            }
        }
    }
}
