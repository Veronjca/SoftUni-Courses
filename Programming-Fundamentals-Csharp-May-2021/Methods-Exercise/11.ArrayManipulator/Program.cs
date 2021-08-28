using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            string finalArray = string.Empty;

            while (input != "end")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "exchange")
                {
                    if (int.Parse(command[1].ToString()) < 0 || int.Parse(command[1].ToString()) > initialArray.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        input = Console.ReadLine();
                        continue;
                    }

                    finalArray = Exchange(command, initialArray);
                    initialArray = finalArray
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();                 
                }
                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        string result = GetMaxOrMinEven(command[0], initialArray);
                        Console.WriteLine(result);
                    }
                    else if (command[1] == "odd")
                    {
                        string result = GetMaxOrMinOdd(command[0], initialArray);
                        Console.WriteLine(result);
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        string result = GetMaxOrMinEven(command[0], initialArray);
                        Console.WriteLine(result);
                    }
                    else if (command[1] == "odd")
                    {
                        string result = GetMaxOrMinOdd(command[0], initialArray);
                        Console.WriteLine(result);
                    }
                }
                else if (command[0] == "first")
                {
                    if (int.Parse(command[1].ToString()) > initialArray.Length)
                    {
                        Console.WriteLine("Invalid count");
                        input = Console.ReadLine();
                        continue;
                    }

                    if (command[2] == "even")
                    {
                        string[] result = GetFirstEvenOrOdd(command[1], command[2], initialArray);
                        if (result.Length == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else
                        {
                            Console.WriteLine($"[{String.Join(", ", result)}]");
                        }

                    }
                    else if (command[2] == "odd")
                    {
                        string[] result = GetFirstEvenOrOdd(command[1], command[2], initialArray);
                        if (result.Length == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else
                        {
                            Console.WriteLine($"[{String.Join(", ", result)}]");
                        }

                    }
                }
                else if (command[0] == "last")
                {
                    if (int.Parse(command[1].ToString()) > initialArray.Length)
                    {
                        Console.WriteLine("Invalid count");
                        input = Console.ReadLine();
                        continue;
                    }

                    if (command[2] == "even")
                    {
                        string[] result = GetLastEvenOrOdd(command[1], command[2], initialArray);
                        if (result.Length == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else
                        {
                            Console.WriteLine($"[{String.Join(", ", result)}]");
                        }

                    }
                    else if (command[2] == "odd")
                    {
                        string[] result = GetFirstEvenOrOdd(command[1], command[2], initialArray);
                        if (result.Length == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else
                        {
                            Console.WriteLine($"[{String.Join(", ", result)}]");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{String.Join(", ", initialArray)}]");
        }

        private static string[] GetLastEvenOrOdd(string count, string command, int[] initialArray)
        {
            int counter = int.Parse(count.ToString());
            string result = string.Empty;

            for (int i = initialArray.Length - 1; i >= 0; i--)
            {
                if (command == "even")
                {
                    if (initialArray[i] % 2 == 0)
                    {
                        counter--;
                        result += initialArray[i] + " ";
                    }
                }
                else if (command == "odd")
                {
                    if (initialArray[i] % 2 != 0)
                    {
                        counter--;
                        result += initialArray[i] + " ";
                    }
                }

                if (counter <= 0)
                {
                    break;
                }
            }

            result.Reverse();
            return result.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        private static string[] GetFirstEvenOrOdd(string count, string command, int[] initialArray)
        {
            int counter = int.Parse(count.ToString());
            string result = string.Empty;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (command == "even")
                {
                    if (initialArray[i] % 2 == 0)
                    {
                        counter--;
                        result += initialArray[i] + " ";
                    }
                }
                else if (command == "odd")
                {
                    if (initialArray[i] % 2 != 0)
                    {
                        counter--;
                        result += initialArray[i] + " ";
                    }
                }

                if (counter <= 0)
                {
                    break;
                }
            }
            return result.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        private static string GetMaxOrMinOdd(string firstCommand, int[] finalArray)
        {
            int maxOddElement = int.MinValue;
            int minOddElement = int.MaxValue;

            int indexOfMinOddElement = 0;
            int indexOfMaxOddElement = 0;

            string result = string.Empty;

            int counter = 0;

            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i] % 2 != 0)
                {
                    counter++;
                    if (finalArray[i] >= maxOddElement)
                    {
                        maxOddElement = finalArray[i];
                        indexOfMaxOddElement = i;
                    }
                    if (finalArray[i] <= minOddElement)
                    {
                        minOddElement = finalArray[i];
                        indexOfMinOddElement = i;
                    }
                }
            }

            if (counter == 0)
            {
                result = "No matches";
                return result;
            }
            if (firstCommand == "min")
            {
                result = indexOfMinOddElement.ToString();
                return result;
            }
            else
            {
                result = indexOfMaxOddElement.ToString();
                return result;
            }
        }

        private static string GetMaxOrMinEven(string firstCommand, int[] finalArray)
        {
            int maxEvenElement = int.MinValue;
            int minEvenElement = int.MaxValue;

            int indexOfMaxEvenElement = 0;
            int indexOfMinEvenElement = 0;

            string result = string.Empty;

            int counter = 0;

            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i] % 2 == 0)
                {
                    counter++;
                    if (finalArray[i] >= maxEvenElement)
                    {
                        maxEvenElement = finalArray[i];
                        indexOfMaxEvenElement = i;
                    }
                    if (finalArray[i] <= minEvenElement)
                    {
                        minEvenElement = finalArray[i];
                        indexOfMinEvenElement = i;
                    }
                }

            }

            if (counter == 0)
            {
                result = "No matches";
                return result;
            }
            if (firstCommand == "min")
            {
                result = indexOfMinEvenElement.ToString();
                return result;
            }
            else
            {
                result = indexOfMaxEvenElement.ToString();
                return result;
            }
        }

        private static string Exchange(string[] command, int[] initialArray)
        {
            int index = int.Parse(command[1].ToString());

            int[] rightSubArray = new int[index + 1];
            int[] leftSubArray = new int[initialArray.Length - index - 1];
            string finalArray = string.Empty;

            for (int i = 0; i < index + 1; i++)
            {
                rightSubArray[i] = initialArray[i];
            }
            int counter = 1;

            for (int i = 0; i < initialArray.Length - index - 1; i++)
            {
                leftSubArray[i] = initialArray[index + counter++];
            }

            finalArray = String.Join(" ", leftSubArray) + " " + String.Join(" ", rightSubArray);

            return finalArray;
        }
    }
}
