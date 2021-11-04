using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> citizensAndPets = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (info[0])
                {
                    case "Citizen":
                        string citizenName = info[1];
                        int age = int.Parse(info[2]);
                        string id = info[3];
                        string birthdate = info[4];
                        citizensAndPets.Add(new Citizen(citizenName, age, id, birthdate));
                        break;
                    case "Pet":
                        string petName = info[1];
                        string petBirthdate = info[2];
                        citizensAndPets.Add(new Pet(petName, petBirthdate));
                        break;

                }
            }

            int year = int.Parse(Console.ReadLine());
            foreach (var item in citizensAndPets)
            {
                int currentYear = int.Parse(item.Birthdate.Substring(item.Birthdate.Length - 4));
                if (year == currentYear)
                {
                    Console.WriteLine(item.Birthdate);
                }
            }

        }
    }
}
