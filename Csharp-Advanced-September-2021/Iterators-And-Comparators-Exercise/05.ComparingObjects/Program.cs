using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                int age =int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                peoples.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine());
            int countOfMatches = 0;
            int countOfNotEqual = 0;
            Person personToCompare = peoples[n-1];

            if (peoples.Count > n)
            {
                foreach (var person in peoples)
                {
                    int result = personToCompare.CompareTo(person);
                    if (result == 0)
                    {
                        countOfMatches++;
                    }
                    else
                    {
                        countOfNotEqual++;
                    }
                }
            }         
            
            Console.WriteLine(countOfMatches > 0 ? $"{countOfMatches} {countOfNotEqual} {peoples.Count}" : "No matches");
        }
    }
}
