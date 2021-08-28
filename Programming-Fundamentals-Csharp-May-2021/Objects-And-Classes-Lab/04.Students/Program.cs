using System;
using System.Collections.Generic;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> allStudents = new List<Student>();

            while (input != "end")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student();

                student.FirstName = inputArgs[0];
                student.LastName = inputArgs[1];
                student.Age = inputArgs[2];
                student.Hometown = inputArgs[3];

                allStudents.Add(student);

                input = Console.ReadLine();
            }


            string nameOfCity = Console.ReadLine();

            foreach (Student student in allStudents)
            {
                if (student.Hometown == nameOfCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }
    }
}
