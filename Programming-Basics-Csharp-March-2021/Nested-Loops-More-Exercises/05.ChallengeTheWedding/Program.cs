using System;

namespace ChallengeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int ladies = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 1; i <= men; i++)
            {
                for (int j = 1; j <= ladies; j++)
                {
                    Console.Write($"({i} <-> {j}) ");
                    counter += 1;
                    if (counter >= tables)
                    {
                        return;
                    }
                }
            }
        }
    }
}
