using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int numberOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                Person currentPerson = new Person(firstName, lastName, age);
                people.Add(currentPerson);
            }

           people.OrderBy(x => x.FirstName).ThenBy(x => x.Age).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
