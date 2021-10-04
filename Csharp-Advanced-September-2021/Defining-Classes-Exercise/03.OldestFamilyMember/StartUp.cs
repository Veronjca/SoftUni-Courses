using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family members = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                int age = int.Parse(info[1]);
                members.AddMember(new Person(name, age));
            }

            Console.WriteLine($"{members.GetOldestMember().Name} {members.GetOldestMember().Age}");
        }
    }
}
