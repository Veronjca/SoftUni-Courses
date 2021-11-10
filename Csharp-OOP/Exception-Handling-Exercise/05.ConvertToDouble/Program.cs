using System;

namespace _05.ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = 
                {
                "-1,035.77219", 
                "blqks", 
                "6.34",
                "100",
                "-21.5",
                "1", 
                "muhahah",
                "1.29e325",
            };
            double result;

            foreach (string value in values)
            {
                try
                {
                    result = Convert.ToDouble(value);
                    if (double.IsPositiveInfinity(result) || double.IsNegativeInfinity(result))
                    {
                        throw new OverflowException();
                    }
                    Console.WriteLine($"Converted '{value}' to {result}.");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to convert '{value}' to a Double.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"'{value}' is outside the range of a Double.");
                }
            }
        }
    }
}
