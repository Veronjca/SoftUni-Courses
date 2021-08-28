using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

           
            int totalSum = 0;
            int num = int.Parse(number);
         

            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());

                int sum = 1;

                for (int j = 1; j <= currentDigit; j++)
                {
                    sum *= j;
                }


                totalSum += sum;
                
            }

            if (totalSum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
