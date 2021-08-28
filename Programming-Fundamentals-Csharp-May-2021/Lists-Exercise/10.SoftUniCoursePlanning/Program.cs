using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialSchedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "course start")
            {
                string[] commandArgs = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs[0] == "Add")
                {
                    AddLesson(initialSchedule, commandArgs[1]);
                }
                else if (commandArgs[0] == "Insert")
                {
                    InsertLesson(initialSchedule, commandArgs[1], commandArgs[2]);
                }
                else if (commandArgs[0] == "Remove")
                {
                    RemoveLesson(initialSchedule, commandArgs[1]);
                }
                else if (commandArgs[0] == "Swap")
                {
                    SwapLessons(initialSchedule, commandArgs[1], commandArgs[2]);
                }
                else if (commandArgs[0] == "Exercise")
                {
                    AddExercise(initialSchedule, commandArgs[1]);
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < initialSchedule.Count; i++)
            {
                Console.WriteLine($"{i+1}.{initialSchedule[i]}");
            }
        }

        private static void AddExercise(List<string> initialSchedule, string lessonTitle)
        {
            bool isLessonExists = initialSchedule.Contains(lessonTitle);
            bool isExerciseExists = initialSchedule.Contains($"{lessonTitle}-Exercise");

            if (isLessonExists && isExerciseExists == false)
            {
                int lessonIndex = initialSchedule.IndexOf(lessonTitle);
                initialSchedule.Insert(lessonIndex + 1, $"{lessonTitle}-Exercise");
            }
            else if (isLessonExists == false)
            {
                initialSchedule.Add(lessonTitle);
                initialSchedule.Add($"{lessonTitle}-Exercise");
            }
        }

        private static void SwapLessons(List<string> initialSchedule, string firstLessonTitle, string secondLessonTitle)
        {
           
            bool isExercise1Exists = initialSchedule.Contains($"{firstLessonTitle}-Exercise");
            bool isExercise2Exists = initialSchedule.Contains($"{secondLessonTitle}-Exercise");

            bool flag = initialSchedule.Contains(firstLessonTitle); 
            bool secondFlag = initialSchedule.Contains(secondLessonTitle); 

            int indexOfFirstLessonTitle = initialSchedule.IndexOf(firstLessonTitle);
            int indexOfSecondLessonTitle = initialSchedule.IndexOf(secondLessonTitle);

            if (flag && secondFlag)
            {
                initialSchedule.RemoveAt(indexOfFirstLessonTitle);
                initialSchedule.Insert(indexOfFirstLessonTitle, secondLessonTitle);

                initialSchedule.RemoveAt(indexOfSecondLessonTitle);
                initialSchedule.Insert(indexOfSecondLessonTitle, firstLessonTitle);

            }

            indexOfFirstLessonTitle = initialSchedule.IndexOf(firstLessonTitle);
            indexOfSecondLessonTitle = initialSchedule.IndexOf(secondLessonTitle);

            if (isExercise1Exists)
            {
                initialSchedule.RemoveAt(initialSchedule.IndexOf($"{firstLessonTitle}-Exercise"));
                initialSchedule.Insert(indexOfFirstLessonTitle + 1, $"{firstLessonTitle}-Exercise");
            }
            if (isExercise2Exists)
            {
                initialSchedule.RemoveAt(initialSchedule.IndexOf($"{secondLessonTitle}-Exercise"));
                initialSchedule.Insert(indexOfSecondLessonTitle + 1, $"{secondLessonTitle}-Exercise");
            }
        }

        private static void RemoveLesson(List<string> initialSchedule, string lessonTitle)
        {
            string exercise = $"{lessonTitle}-Exercise";

            bool flag = initialSchedule.Contains(lessonTitle);
            bool secondFlag = initialSchedule.Contains(exercise);
            
            if (flag)
            {
                initialSchedule.Remove(lessonTitle);
            }
            if (secondFlag)
            {
                initialSchedule.Remove(exercise);
            }
        }

        private static void InsertLesson(List<string> initialSchedule, string lessonTitle, string index)
        {
            bool flag = initialSchedule.Contains(lessonTitle);

            if (flag == false)
            {
                initialSchedule.Insert(int.Parse(index), lessonTitle);
            }
        }

        private static void AddLesson(List<string> initialSchedule, string lessonTitle)
        {
            bool flag = initialSchedule.Contains(lessonTitle);

            if (flag == false)
            {
                initialSchedule.Add(lessonTitle);
            }
        }
    }
}
