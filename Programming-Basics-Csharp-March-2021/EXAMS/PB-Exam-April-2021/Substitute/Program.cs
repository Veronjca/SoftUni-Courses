using System;

namespace Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
           int K = int.Parse(Console.ReadLine());
           int L = int.Parse(Console.ReadLine());
           int M = int.Parse(Console.ReadLine());
           int N = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = K; i <= 8; i++)
            {
                for (int j = 9; j >= L; j--)
                {
                    for (int k = M; k <= 8; k++)
                    {
                        for (int l = 9; l >= N; l--)
                        {

                            

                            if (i % 2 == 0 && j % 2 != 0 && k %2 == 0 && l %2 !=0 )
                            {
                                if (i == k && j == l)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{i}{j} - {k}{l}");
                                    count++;
                                }
                                
                            }

                            if (count >= 6)
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
