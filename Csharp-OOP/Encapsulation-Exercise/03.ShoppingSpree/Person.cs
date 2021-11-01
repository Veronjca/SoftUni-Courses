using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
   public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name 
        {
            get => this.name; 
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money 
        { 
            get => this.Money; 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyList<Product> Products => this.products.AsReadOnly();

        public string AddProduct(Product product)
        {
            if (money >= product.Cost)
            {
                this.products.Add(product);
                this.money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }
    }
}
