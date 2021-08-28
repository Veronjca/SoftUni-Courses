using System;
using System.Collections.Generic;
using System.Linq;

namespace TextProcessingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var username in usernames)
            {
                bool flag = false;

                if (username.Length >= 3 && username.Length <= 16)
                {
                    for (int j = 0; j < username.Length; j++)
                    {
                        if (Char.IsDigit(username[j]) || Char.IsLetter(username[j]) || username[j] == 45 || username[j] == 95)
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                            break;
                        }
                    }
                  
                }
                else
                {
                    flag = true;
                }

                if (!flag)
                {
                    Console.WriteLine(username);
                }
            }

            
        }
    }
}
