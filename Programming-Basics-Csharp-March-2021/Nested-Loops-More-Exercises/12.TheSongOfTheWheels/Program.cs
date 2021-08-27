using System;

namespace TheSongOfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            string password = "";

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            if (i * j + k * l == n)
                            {
                                if (i < j && k > l)
                                {
                                    Console.Write($"{i}{j}{k}{l} ");
                                    counter++;
                                    if (counter == 4)
                                    {
                                        password = $"{i}{j}{k}{l}";
                                    }
                                }
                            }
                           
                        }
                    }
                }
            }
            Console.WriteLine();
            if (counter >= 4)
            {
                
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine("No!");
            }
            
        }
    }
}
