using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Private> privates = new List<Private>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string id = commands[1]; 
                string firstName = commands[2];
                string lastName = commands[3];
                string corps;
                decimal salary;
                
                Private currentPrivate = null;
                LieutenantGeneral currentLieutenant = null;
                Engineer currentEngineer = null;
                Commando currentCommando = null;

                switch (commands[0])
                {
                    case "Private":
                        salary = decimal.Parse(commands[4]);
                        currentPrivate = new Private(id, firstName, lastName, salary);
                        privates.Add(currentPrivate);
                        Console.WriteLine(currentPrivate);
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(commands[4]);
                        currentLieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < commands.Length ; i++)
                        {
                            currentLieutenant.Privates.Add(privates.FirstOrDefault(p => p.Id == commands[i]));
                        }
                        Console.WriteLine(currentLieutenant);
                        break;
                    case "Engineer":
                        if (commands[5] == "Marines" || commands[5] == "Airforces")
                        {
                            salary = decimal.Parse(commands[4]);
                            corps = commands[5];
                            currentEngineer = new Engineer(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < commands.Length; i+=2)
                            {
                                currentEngineer.Repairs.Add(new Repair(commands[i], int.Parse(commands[i + 1])));
                            }
                            Console.WriteLine(currentEngineer);
                        }                        
                        break;
                    case "Commando":
                        if (commands[5] == "Marines" || commands[5] == "Airforces")
                        {
                            salary = decimal.Parse(commands[4]);
                            corps = commands[5];
                            currentCommando = new Commando(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < commands.Length; i += 2)
                            {
                                if (commands[i + 1] == "inProgress" || commands[i + 1] == "Finished")
                                {
                                    currentCommando.Missions.Add(new Mission(commands[i], commands[i + 1]));
                                }
                            }
                            Console.WriteLine(currentCommando);
                        }                       
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(commands[4]);
                        Spy currentSpy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(currentSpy);
                        break;
                }

            }
        }
    }
}
