using System;

namespace SecretDoorsLock
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit100 = int.Parse(Console.ReadLine());
            int upperLimit10 = int.Parse(Console.ReadLine());
            int upperLimit1 = int.Parse(Console.ReadLine());
            

            for (int i = 1; i <= upperLimit100; i++)
            {
                for (int j = 2; j <= upperLimit10; j++)
                {
                    for (int k = 1; k <= upperLimit1; k++)
                    {
                        if (i % 2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                if (k % 2 == 0)
                                {
                                    Console.WriteLine($"{i}{j}{k}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
