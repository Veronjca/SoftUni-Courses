using System;

namespace PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            //началната стойност на  първата двойка числа 
            int n1 = int.Parse(Console.ReadLine());
            //началната стойност на втората двойка числа 
            int n2 = int.Parse(Console.ReadLine());
            // разликата между началната и крайната стойност на първата двойка
            int n3 = int.Parse(Console.ReadLine());
            // разликата между началната и крайната стойност на  втората двойка числа 
            int n4 = int.Parse(Console.ReadLine());


            for (int i = n1; i <= n1 + n3; i++)
            {
                for (int j = n2; j <= n2 + n4; j++)
                {
                    bool ifPrime1 = true;
                    for (int k = 2; k <= Math.Sqrt(i); k++)
                    {
                        if (i % k == 0)
                        {
                            ifPrime1 = false;
                        }
                    }

                    bool ifprime2 = true;

                    for (int l = 2; l <= Math.Sqrt(j); l++)
                    {
                        if (j % l == 0)
                        {
                            ifprime2 = false;
                        }
                    }
                    if (ifPrime1 && ifprime2)
                    {
                        Console.WriteLine($"{i}{j}");
                    }

                }
            }
        }
    }

}
