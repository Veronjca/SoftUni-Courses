using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            ConvertToString(input);
        }

        private static void ConvertToString(int input)
        {
            for (int i = 1; i <= input; i++)
            {
                string number = i.ToString();

                Sum(number);                
            }
        }

        private static void Sum(string number)
        {
            int sum = 0;

            for (int j = 0; j < number.Length; j++)
            {
                sum += int.Parse(number[j].ToString());
            }

           bool ifCanDivide = DivideSum(sum);
           int ifConsistOddNumber = IfConsistOddNumber(number);
           IsTheNumberMaster(ifCanDivide, ifConsistOddNumber, number);
        }

        private static void IsTheNumberMaster(bool ifCanDivide, int ifConsistOddNumber, string number)
        {
            if (ifCanDivide && ifConsistOddNumber >= 1)
            {
                Console.WriteLine(number);
            }
        }

        private static int IfConsistOddNumber(string number)
        {
            int counter = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());

                if (currentDigit % 2 != 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static bool DivideSum(int sum)
        {
            bool ifCanDivide = false;

            if (sum % 8 == 0)
            {
                ifCanDivide = true;
            }

            return ifCanDivide;
        }
    }
}
