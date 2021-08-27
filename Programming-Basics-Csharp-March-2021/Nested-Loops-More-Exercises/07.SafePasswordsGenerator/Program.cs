using System;

namespace SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int combinations = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 35; i <= 55; i++)
            {
                for (int j = 64; j <= 96; j++)
                {
                    for (int k = 1; k <= a; k++)
                    {
                        for (int l = 1; l <= b; l++)
                        {
                            if (i > 55)
                            {
                                i = 35;
                            }
                            if (j > 96)
                            {
                                j = 64;
                            }

                            Console.Write($"{(char)i}{(char)j}{k}{l}{(char)j}{(char)i}|");
                            i++;
                            j++;
                            counter++;
                            if (k == a && l == b)
                            {
                                return;
                            }
                            if (counter >= combinations)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
