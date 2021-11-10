using System;

namespace _03.FixingVol._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            byte result;

            firstNumber = 30;
            secondNumber = 60;
            
            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
                Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
            }
            catch (OverflowException ex )
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
