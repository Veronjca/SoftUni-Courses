using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> products = Console.ReadLine()
            //    .Split("|")
            //    .ToList();

            //string command = Console.ReadLine();

            //while (command != "Shop!")
            //{

            //    string[] commandArgs = command.Split("%");             

            //    if (commandArgs[0] == "Important")
            //    {
            //        bool isContaining = products.Contains(commandArgs[1]);

            //        if (isContaining)
            //        {
            //            int index = products.IndexOf(commandArgs[1]);
            //            products.RemoveAt(index);
            //            products.Insert(0, commandArgs[1]);
            //        }
            //        else 
            //        {
            //            products.Insert(0, commandArgs[1]);
            //        }
            //    }
            //    else if (commandArgs[0] == "Add")
            //    {
            //        bool isContaining = products.Contains(commandArgs[1]);

            //        if (isContaining)
            //        {
            //            Console.WriteLine("The product is already in the list.");
            //        }
            //        else
            //        {
            //            products.Add(commandArgs[1]);
            //        }
            //    }
            //    else if (commandArgs[0] == "Swap")
            //    {
            //        bool isFirstProductExists = products.Contains(commandArgs[1]);
            //        bool isSecondProductExists = products.Contains(commandArgs[2]);

            //        if (!isFirstProductExists)
            //        {
            //            Console.WriteLine($"Product {commandArgs[1]} missing!");

            //        }
            //        else if (!isSecondProductExists)
            //        {
            //            Console.WriteLine($"Product {commandArgs[2]} missing!");

            //        }
            //        else
            //        {
            //            int indexOfFirstProduct = products.IndexOf(commandArgs[1]);
            //            int indexOfSecondProduct = products.IndexOf(commandArgs[2]);

            //            products.RemoveAt(indexOfFirstProduct);
            //            products.Insert(indexOfFirstProduct, commandArgs[2]);


            //            products.RemoveAt(indexOfSecondProduct);
            //            products.Insert(indexOfSecondProduct, commandArgs[1]);

            //        }
            //    }
            //    else if (commandArgs[0] == "Remove")
            //    {
            //        bool isExist = products.Contains(commandArgs[1]);

            //        if (isExist)
            //        {
            //            products.Remove(commandArgs[1]);
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Product {commandArgs[1]} isn't in the list.");
            //        }
            //    }
            //    else if (commandArgs[0] == "Reversed")
            //    {
            //        products.Reverse();
            //    }


            //    command = Console.ReadLine();
            //}


            //for (int i = 0; i < products.Count; i++)
            //{
            //    Console.WriteLine($"{i + 1}. {products[i]}");
            //}


            List<string> products = Console.ReadLine().Split("|").ToList();

            string command = Console.ReadLine();

            while (command != "Shop!")
            {

                string[] splitted = command.Split("%");

                if (splitted[0] == "Important")
                {
                    if (products.Contains(splitted[1]))
                    {
                        int index = products.IndexOf(splitted[1]);
                        products.RemoveAt(index);
                        products.Insert(0, splitted[1]);
                    }
                    else
                    {
                        products.Insert(0, splitted[1]);
                    }
                }

                if (splitted[0] == "Add")
                {
                    if (products.Contains(splitted[1]))
                    {
                        Console.WriteLine("The product is already in the list.");
                    }
                    else
                    {
                        products.Add(splitted[1]);
                    }
                }

                if (splitted[0] == "Swap")
                {
                    if (!products.Contains(splitted[1]))
                    {
                        Console.WriteLine($"Product {splitted[1]} missing!");
                    }
                    else if (!products.Contains(splitted[2]))
                    {
                        Console.WriteLine($"Product {splitted[2]} missing!");
                    }
                    else
                    {
                        int indexOfFirstProduct = products.IndexOf(splitted[1]);
                        int indexOfSecondProduct = products.IndexOf(splitted[2]);

                        products.RemoveAt(indexOfFirstProduct);
                        products.Insert(indexOfFirstProduct, splitted[2]);


                        products.RemoveAt(indexOfSecondProduct);
                        products.Insert(indexOfSecondProduct, splitted[1]);
                    }
                }

                if (splitted[0] == "Remove")
                {
                    if (products.Contains(splitted[1]))
                    {
                        products.Remove(splitted[1]);
                    }
                    else
                    {
                        Console.WriteLine($"Product {splitted[1]} isn't in the list.");
                    }
                }

                if (splitted[1] == "Reverse")
                {
                    products.Reverse();
                }



                command = Console.ReadLine();
            }

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }
    }
}
