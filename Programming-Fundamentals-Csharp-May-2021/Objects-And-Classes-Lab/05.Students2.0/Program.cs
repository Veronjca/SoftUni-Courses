using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
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



                if (IsStudentExisting(allStudents, inputArgs[0], inputArgs[1]))
                {
                    Student student = allStudents.FirstOrDefault(x => x.FirstName == inputArgs[0] && x.LastName == inputArgs[1]);

                    student.FirstName = inputArgs[0];
                    student.LastName = inputArgs[1];
                    student.Age = inputArgs[2];
                    student.Hometown = inputArgs[3];

                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = inputArgs[0],
                        LastName = inputArgs[1],
                        Age = inputArgs[2],
                        Hometown = inputArgs[3],
                    };



                    allStudents.Add(student);
                }




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

        private static bool IsStudentExisting(List<Student> allStudents, string firstName, string lastName)
        {
            foreach (Student student in allStudents)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }

            }

            return false;
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
