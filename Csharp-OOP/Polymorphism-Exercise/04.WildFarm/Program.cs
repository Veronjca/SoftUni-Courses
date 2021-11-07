using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
   public class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "End")
            {
                Animal currentAnimal = null;
                Food currentFood = null;

                    string[] animalInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string[] foodInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = String.Empty;
                    string breed = String.Empty;
                    double wingSize;
                    int foodQuantity = int.Parse(foodInfo[1]);
                    switch (animalInfo[0])
                    {
                        case "Cat":
                            livingRegion = animalInfo[3];
                            breed = animalInfo[4];
                            currentAnimal = new Cat(name, weight, livingRegion, breed);
                            animals.Add(currentAnimal);
                            break;
                        case "Dog":
                            livingRegion = animalInfo[3];
                            currentAnimal = new Dog(name, weight, livingRegion);
                            animals.Add(currentAnimal);
                            break;
                        case "Hen":
                            wingSize = double.Parse(animalInfo[3]);
                            currentAnimal = new Hen(name, weight, wingSize);
                            animals.Add(currentAnimal);
                            break;
                        case "Mouse":
                            livingRegion = animalInfo[3];
                            currentAnimal = new Mouse(name, weight, livingRegion);
                            animals.Add(currentAnimal);
                            break;
                        case "Owl":
                            wingSize = double.Parse(animalInfo[3]);
                            currentAnimal = new Owl(name, weight, wingSize);
                            animals.Add(currentAnimal);
                            break;
                        case "Tiger":
                            livingRegion = animalInfo[3];
                            breed = animalInfo[4];
                            currentAnimal = new Tiger(name, weight, livingRegion, breed);
                            animals.Add(currentAnimal);
                            break;
                    }

                    switch (foodInfo[0])
                    {
                        case "Fruit":
                            currentFood = new Fruit(foodQuantity);
                            break;
                        case "Meat":
                            currentFood = new Meat(foodQuantity);
                            break;
                        case "Seeds":
                            currentFood = new Seeds(foodQuantity);
                            break;
                        case "Vegetable":
                            currentFood = new Vegetable(foodQuantity);
                            break;
                    }
                    Console.WriteLine(currentAnimal.ProduceSound());
                    currentAnimal.EatFood(currentFood);
            }

            animals.ForEach(a => Console.WriteLine(a));
        }
    }
}
