using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string student = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (students.ContainsKey(student))
                {
                    students[student].Add(grade);
                }
                else
                {
                    students.Add(student, new List<decimal>() {grade});
                }


            }

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {String.Join(" ", item.Value.Select(x => $"{x:f2}"))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
