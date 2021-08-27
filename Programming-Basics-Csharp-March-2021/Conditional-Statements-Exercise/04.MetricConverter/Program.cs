using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();

            double result = 0.0;

            if ((inputMetric == "mm") && (outputMetric == "m"))
            {
                result = number / 1000;
            }
            else if ((inputMetric == "mm") && (outputMetric == "cm"))
            {
                result = number / 10;
            }

            if ((inputMetric == "m") && (outputMetric == "mm"))
            {
                result = number * 1000;
            }
            
            else if ((inputMetric == "m") && (outputMetric == "cm"))
            {
                result = number * 100;
            }
           
            if ((inputMetric == "cm") && (outputMetric == "m"))
            {
                result = number / 100;
            }

            else if ((inputMetric == "cm") && (outputMetric == "mm"))
            {
                result = number * 10;
            }
            
            Console.WriteLine($"{result:F3}");
        }
    }
}
            
    
