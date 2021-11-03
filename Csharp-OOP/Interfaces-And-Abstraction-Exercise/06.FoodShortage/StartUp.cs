using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Rebel> rebels = new List<Rebel>();
            List<Citizen> citizens = new List<Citizen>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 4)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    string birthdate = info[3];

                    citizens.Add(new Citizen(name, age, id, birthdate));
                }
                else if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string group = info[2];
                    rebels.Add(new Rebel(name, age, group));
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (rebels.FirstOrDefault(r => r.Name == input) != null)
                {
                    rebels.FirstOrDefault(r => r.Name == input).BuyFood();
                }
                if (citizens.FirstOrDefault(c => c.Name == input) != null)
                {
                    citizens.FirstOrDefault(c => c.Name == input).BuyFood();
                }
            }

            Console.WriteLine(rebels.Sum(r => r.Food) + citizens.Sum(c => c.Food));
        }
    }
}
