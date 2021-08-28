using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Empty;


            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            int counter = 0;

            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                   
                }
                counter++;

                if (counter >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;

                }

                Console.WriteLine("Incorrect password. Try again.");

            }


            




        }
    }
}
