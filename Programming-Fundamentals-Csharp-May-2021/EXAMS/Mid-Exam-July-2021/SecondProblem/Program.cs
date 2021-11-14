using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> particles = Console.ReadLine()
                 .Split("|", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List <string> result = new List<string> ();

                if (commandArgs[0] == "Add" && int.Parse(commandArgs[2]) >= 0 && int.Parse(commandArgs[2]) < particles.Count)
                {
                    particles.Insert(int.Parse(commandArgs[2]), commandArgs[1]);
                }
                else if (commandArgs[0] == "Remove" && int.Parse(commandArgs[1]) >= 0 && int.Parse(commandArgs[1]) < particles.Count)
                {
                    particles.RemoveAt(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Check")
                {

                    if (commandArgs[1] == "Even")
                    {
                        for (int i = 0; i < particles.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                result.Add(particles[i]);
                            }
                        }
                    }
                    else if (commandArgs[1] == "Odd")
                    {
                        for (int i = 0; i < particles.Count; i++)
                        {
                            if (i % 2 != 0)
                            {
                                result.Add(particles[i]);
                            }
                        }
                    }

                    Console.WriteLine(String.Join(" ", result));
                }

                command = Console.ReadLine();
            }

            string weaponName = String.Join("", particles);

            Console.WriteLine($"You crafted {weaponName}!");
        }
    }
}

