using System;

namespace Basic_Syntax__Conditional_Statements_and_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double age = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {averageGrade:f2}");
        }
    }
}
