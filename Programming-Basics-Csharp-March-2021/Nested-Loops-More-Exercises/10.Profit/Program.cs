using System;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int coins1lv = int.Parse(Console.ReadLine());
            int coins2lv = int.Parse(Console.ReadLine());
            int notes5lv = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= coins1lv; i++)
            {
                for (int j = 0; j <= coins2lv; j++)
                {
                    for (int k = 0; k <= notes5lv; k++)
                    {
                        int neededSum = i * 1 + j * 2 + k * 5;

                        if (neededSum == sum)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }

                    }
                }
            }
        }
    }
}
