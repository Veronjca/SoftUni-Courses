using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> citizensAndRobots = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    citizensAndRobots.Add(new Citizen(name, age, id));
                }
                else if (info.Length == 2)
                {
                    string model = info[0];
                    string id = info[1];

                    citizensAndRobots.Add(new Robot(model, id));
                }
            }

            string number = Console.ReadLine();
            int numberAsNumber = int.Parse(number);

            FindFakeIds<IIdentifiable>(citizensAndRobots, number, numberAsNumber);
        }

        private static void FindFakeIds<T>(List<IIdentifiable> collection, string number, int numberAsNumber)
        {
            foreach (var item in collection)
            {
                int lastDigits = int.Parse(item.Id.Substring(item.Id.Length - number.Length));
                if (lastDigits == numberAsNumber)
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
