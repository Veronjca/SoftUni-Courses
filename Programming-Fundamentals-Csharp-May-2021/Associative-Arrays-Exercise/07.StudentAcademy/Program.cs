using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairOfRows = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsInfo = new Dictionary<string, List<double>>();

            for (int i = 0; i < pairOfRows; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (studentsInfo.ContainsKey(studentName))
                {
                    studentsInfo[studentName].Add(studentGrade);
                }
                else
                {
                    studentsInfo.Add(studentName, new List<double>());
                    studentsInfo[studentName].Add(studentGrade);
                }
            }

            studentsInfo = studentsInfo.Where(x => x.Value.Sum() / x.Value.Count >= 4.50).OrderByDescending(x => x.Value.Sum() / x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in studentsInfo)
            {
               double averageGrade = item.Value.Sum() / item.Value.Count;
                Console.WriteLine($"{item.Key} -> {averageGrade:f2}" );
            }
        }
    }
}
