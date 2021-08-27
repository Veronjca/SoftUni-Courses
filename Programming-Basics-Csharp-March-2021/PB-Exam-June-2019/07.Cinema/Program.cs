using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double profit = 0;

            while (input != "Movie time!")
            {
                double people = double.Parse(input);

                if (people > capacity)
                {
                    Console.WriteLine("The cinema is full.");
                    Console.WriteLine($"Cinema income - {profit} lv.");
                    return;
                }

                capacity -= people;

                
                profit += people * 5;

                if (people % 3 == 0)
                {
                    profit -= 5;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"There are {capacity} seats left in the cinema.");
            Console.WriteLine($"Cinema income - {profit} lv.");
        }
    }
}
