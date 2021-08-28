using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();

            if (valueType == "int")
            {
                int firstValue = int.Parse(Console.ReadLine());
                int secondValue = int.Parse(Console.ReadLine());
                int getMax = GetMaxInteger(firstValue, secondValue);
                Console.WriteLine(getMax);
            }
            else if (valueType == "char")
            {
                char firstValue = char.Parse(Console.ReadLine());
                char secondValue = char.Parse(Console.ReadLine());
                char getMax = GetMaxChar(firstValue, secondValue);
                Console.WriteLine(getMax);
            }
            else if (valueType == "string")
            {
                string firstValue = Console.ReadLine();
                string secondValue = Console.ReadLine();
                string getMax = GetMaxString(firstValue, secondValue);
                Console.WriteLine(getMax);
            }
        }

        private static string GetMaxString(string firstValue, string secondValue)
        {
            int result = firstValue.CompareTo(secondValue);

            if (result < 0)
            {
                return secondValue;
            }
          
                return firstValue;
            
            
        }

        private static char GetMaxChar(char firstValue, char secondValue)
        {
            if (firstValue > secondValue)
            {
                return firstValue;
            }

            return secondValue;
        }

        private static int GetMaxInteger(int firstValue, int secondValue)
        {
            if (firstValue > secondValue)
            {
                return firstValue;
            }

            return secondValue;
        }
    }
}
