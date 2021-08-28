using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> people = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool add = true;

                bool remove = true;

                if (commandArgs[2] == "going!")
                {
                    if (people.Count != 0)
                    {
                        for (int j = 0; j < people.Count; j++)
                        {
                            if (commandArgs[0] == people[j])
                            {
                                Console.WriteLine($"{commandArgs[0]} is already in the list!");
                                add = true;
                                break;
                            }
                            else
                            {
                                add = false;
                            }
                        }
                    }
                    else
                    {
                        add = false;
                    }
                   
                }
                else if (commandArgs[2] == "not")
                {
                    if (people.Count != 0)
                    {
                        for (int k = 0; k < people.Count; k++)
                        {
                            if (commandArgs[0] == people[k])
                            {
                                people.Remove(commandArgs[0]);
                                remove = true;
                                break;
                            }
                            else
                            {
                                remove = false;
                            }
                        }
                    }
                    else
                    {
                        remove = false;
                    }
                    
                }

                if (add == false)
                {
                    people.Add(commandArgs[0]);
                }
                if (remove == false)
                {
                    Console.WriteLine($"{commandArgs[0]} is not in the list!");
                }

                    
            }

            foreach (var i in people)
            {
                Console.WriteLine(i);
            }
        }
    }
}
