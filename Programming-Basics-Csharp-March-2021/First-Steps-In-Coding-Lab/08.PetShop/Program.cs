using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDogs = int.Parse(Console.ReadLine());
            int numberOfOtherAnimals = int.Parse(Console.ReadLine());

            double priceOfDogFood = numberOfDogs * 2.50;
            double priceOfOtherAnimalsFood = numberOfOtherAnimals * 4;
            double finalPrice = priceOfDogFood + priceOfOtherAnimalsFood;

            Console.WriteLine($"{finalPrice} lv.");


        }
    }
}
