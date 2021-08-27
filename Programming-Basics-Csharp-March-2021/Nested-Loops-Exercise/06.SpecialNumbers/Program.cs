using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i < 9999; i++)
            {
                
                string currentNum = i.ToString();
                int counter = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int number = int.Parse(currentNum[j].ToString());

                    if (number == 0)
                    {
                       number = int.Parse(currentNum[j].ToString());
                       continue;
                    }
                    if (n % number == 0)
                    {
                        counter++;
                    }
                }
                if (counter == currentNum.Length)
                {
                    Console.Write($"{currentNum} ");
                }
               

            }
        }
    }
}
