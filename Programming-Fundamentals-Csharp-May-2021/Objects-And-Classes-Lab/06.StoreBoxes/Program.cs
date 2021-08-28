using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Box> boxes = new List<Box>();


            while (input != "end")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Item item = new Item()
                {
                    Name = inputArgs[1],
                    Price = decimal.Parse(inputArgs[3])
                };

                Box box = new Box()
                {
                    SerialNumber = inputArgs[0],
                    Item = item,
                    ItemQuantity = double.Parse(inputArgs[2]),
                    PriceForABox = item.Price * decimal.Parse(inputArgs[2]),
                };

                boxes.Add(box);

                input = Console.ReadLine();
            }

           boxes = boxes.OrderByDescending(x => x.PriceForABox).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:F2}");
            }
            
        }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public double ItemQuantity { get; set; }
        public decimal PriceForABox { get; set; }
    }
}
