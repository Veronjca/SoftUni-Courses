using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            int counter = 0;
            while (command != "end")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (commandArgs[0])
                {
                    case "Contains":

                       bool isContains = numbers.Contains(int.Parse(commandArgs[1]));

                        if (isContains)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        EvenNumbers(numbers);
                        break;
                    case "PrintOdd":
                        OddNumbers(numbers);
                        break;
                    case "GetSum":
                        Sum(numbers);
                        break;
                    case "Filter":
                        FilterBy(numbers, commandArgs[1], commandArgs[2]);
                        break;
                    case "Add":
                        counter++;
                        numbers.Add(int.Parse(commandArgs[1]));
                        break;
                    case "Remove":
                        counter++;
                        numbers.Remove(int.Parse(commandArgs[1]));
                        break;
                    case "RemoveAt":
                        counter++;
                        numbers.RemoveAt(int.Parse(commandArgs[1]));
                        break;
                    case "Insert":
                        counter++;
                        numbers.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                        break;

                       
                }

                command = Console.ReadLine();
            }

            if (counter != 0)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        private static void FilterBy(List <int> numbers, string sign, string number)
        {
            List <int> result = new List<int>();

            switch (sign)
            {
                case "<":
                  result = numbers.FindAll(x => x < int.Parse(number));
                    
                    break;
                case ">":
                   result =  numbers.FindAll(x => x > int.Parse(number));
                    break;
                case ">=":
                   result = numbers.FindAll(x => x >= int.Parse(number));
                    break;
                case "<=":
                    result = numbers.FindAll(x => x <= int.Parse(number));
                    break;
            }

                Console.WriteLine(String.Join(" ", result));
           
        }

        private static void Sum(List<int> numbers)
        {
            int sum = 0;

            foreach (var i in numbers)
            {
                sum += i;
            }

            Console.WriteLine(sum);
        }

        private static void OddNumbers(List<int> numbers)
        {
            List<int> result = new List<int>();

            foreach (var i in numbers)
            {
                if (i % 2 != 0)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }

        private static void EvenNumbers(List<int> numbers)
        {
            List<int> result = new List<int>();

            foreach (var i in numbers)
            {
                if (i % 2 == 0)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
