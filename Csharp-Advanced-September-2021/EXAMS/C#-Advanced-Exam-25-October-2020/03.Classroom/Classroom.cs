using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Count => this.students.Count;
        public int Capacity { get; set; }

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student current = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (current == null)
            {
                return "Student not found";
            }
            this.students.Remove(current);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Subject: {subject}");
            output.AppendLine("Students:");
            foreach (var student in this.students.Where(s => s.Subject == subject))
            {
                output.AppendLine($"{student.FirstName} {student.LastName}");
            }
            if (this.students.Where(s => s.Subject == subject).Any())
            {
                return output.ToString().Trim();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
            => this.Count;

        public Student GetStudent(string firstName, string lastName)
            => this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
