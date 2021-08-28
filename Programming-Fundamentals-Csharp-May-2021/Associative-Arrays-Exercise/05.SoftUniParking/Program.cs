using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
           

           Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandInfo[0] == "register")
                {
                    if (registeredUsers.ContainsKey(commandInfo[1]))
                    {
                        string value = String.Empty;
                        registeredUsers.TryGetValue(commandInfo[1], out value);

                        Console.WriteLine($"ERROR: already registered with plate number {value}");
                    }
                    else
                    {
                        registeredUsers.Add(commandInfo[1], commandInfo[2]);
                        Console.WriteLine($"{commandInfo[1]} registered {commandInfo[2]} successfully"); 
                    }
                }
                else if (commandInfo[0] == "unregister")
                {
                    if (!registeredUsers.ContainsKey(commandInfo[1]))
                    {

                        Console.WriteLine($"ERROR: user {commandInfo[1]} not found");
                    }
                    else
                    {
                        registeredUsers.Remove(commandInfo[1]);
                        Console.WriteLine($"{commandInfo[1]} unregistered successfully");
                    }
                }
            }

            foreach (var item in registeredUsers)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
