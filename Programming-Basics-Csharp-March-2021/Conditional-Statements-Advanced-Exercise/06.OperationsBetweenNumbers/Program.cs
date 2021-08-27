using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            double sum = 0;


            switch (operation)
            {
                case "+":
                    sum = N1 + N2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{N1} + {N2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} + {N2} = {sum} - odd");
                    }
                    break;
                case "-":
                    sum = N1 - N2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{N1} - {N2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} - {N2} = {sum} - odd");
                    }
                    break;
                case "*":
                    sum = N1 * N2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{N1} * {N2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} * {N2} = {sum} - odd");
                    }
                    break;
                case "/":
                    if (N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                        return;
                    }
                    sum = N1 / N2;
                    Console.WriteLine($"{N1} / {N2} = {sum:F2}");
                    break;
                case "%":
                    if (N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                        return;
                    }
                    sum = N1 % N2;
                    Console.WriteLine($"{N1} % {N2} = {sum}");
                    break;
            }
        }
    }
}
