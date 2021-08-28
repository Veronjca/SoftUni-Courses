using System;
using System.Numerics;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerOriginalValue = int.Parse(Console.ReadLine());
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            
            int pokes = 0;
            int pokePower = pokePowerOriginalValue;

            while (pokePower >= distanceBetweenTargets)
            {

                pokePower -= distanceBetweenTargets;
                pokes++;

                if (pokePower == pokePowerOriginalValue / 2)
                {
                    if (exhaustionFactor > 0)
                    {
                        pokePower /= exhaustionFactor;
                    }

                }

            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokes);
        }
    }
}
