using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
   public  class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                List<Person> people = new List<Person>();

                for (int i = 0; i < inputPeople.Length; i++)
                {
                    string[] personInfo = inputPeople[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);
                    people.Add(new Person(name, money));

                }

                string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                List<Product> products = new List<Product>();

                for (int i = 0; i < inputProducts.Length; i++)
                {
                    string[] productInfo = inputProducts[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);
                    products.Add(new Product(name, cost));

                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Person currentPerson = people.FirstOrDefault(p => p.Name == commandArgs[0]);
                    Product currentProduct = products.FirstOrDefault(p => p.Name == commandArgs[1]);
                    Console.WriteLine(currentPerson.AddProduct(currentProduct));
                }

                people.ForEach(x => Console.WriteLine(x.Products.Count > 0 ? $"{x.Name} - {String.Join(", ", x.Products)}" : $"{x.Name} - Nothing bought"));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
