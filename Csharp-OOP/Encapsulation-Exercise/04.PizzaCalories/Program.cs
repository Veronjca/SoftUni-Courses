using System;

namespace _04.PizzaCalories
{
   public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string[] doughInput = Console.ReadLine().Split();
                string pizzaName = pizzaInput[1];
                string flourType = doughInput[1];
                string bakingTechnique = doughInput[2];
                int doughWeight = int.Parse(doughInput[3]);
               
                Pizza pizza = new Pizza(pizzaName, new Dough(flourType, bakingTechnique, doughWeight));
           
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArgs = input.Split();
                   
                    string toppingType = inputArgs[1];
                    int toppingWeight = int.Parse(inputArgs[2]);
                    Topping currentTopping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(currentTopping);                 
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
