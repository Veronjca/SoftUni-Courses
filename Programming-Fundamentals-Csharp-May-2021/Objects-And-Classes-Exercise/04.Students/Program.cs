using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            List<Student> allStudents = new List<Student>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Student newStudent = new Student();

                newStudent.FirstName = studentInfo[0];
                newStudent.SecondName = studentInfo[1];
                newStudent.Grade = double.Parse(studentInfo[2]);

                allStudents.Add(newStudent);
            }

            allStudents = allStudents.OrderByDescending(x => x.Grade).ToList();

            foreach (var student in allStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {SecondName}: {Grade:F2}";
            }

        }
    }
}
