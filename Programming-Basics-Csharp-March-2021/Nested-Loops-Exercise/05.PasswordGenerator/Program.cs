using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n_Number = int.Parse(Console.ReadLine());
            int l_number = int.Parse(Console.ReadLine());

            for (int symbol1 = 1; symbol1 < n_Number; symbol1++)
            {
                for (int symbol2 = 1; symbol2 < n_Number; symbol2++)
                {
                    for (int symbol3 = 'a'; symbol3 < 'a' + l_number; symbol3++)
                    {
                        for (int symbol4 = 'a'; symbol4 < 'a' + l_number; symbol4++)
                        {
                            for (int symbol5 = 2; symbol5 <= n_Number; symbol5++)
                            {

                                if (symbol5 > symbol1 && symbol5 > symbol2)
                                {
                                    Console.Write($"{symbol1}{symbol2}{(char)symbol3}{(char)symbol4}{symbol5} ");
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
