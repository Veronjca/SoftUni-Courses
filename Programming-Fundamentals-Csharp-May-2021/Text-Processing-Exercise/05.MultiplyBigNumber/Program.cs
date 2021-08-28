using System;
using System.Numerics;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstMultiplier = BigInteger.Parse(Console.ReadLine());
            int secondMultiplier = int.Parse(Console.ReadLine());

            BigInteger result = firstMultiplier * secondMultiplier;

            Console.WriteLine(result);
        }
    }
}
