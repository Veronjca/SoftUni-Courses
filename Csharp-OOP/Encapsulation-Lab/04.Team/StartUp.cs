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
                decimal salary = decimal.Parse(input[3]);
                Person currentPerson = new Person(firstName, lastName, age, salary);
                people.Add(currentPerson);
            }

            Team team = new Team("Levski");
            foreach (var person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"{team.FirstTeam.Count}{Environment.NewLine}{team.ReserveTeam.Count}");
        }
    }
}
