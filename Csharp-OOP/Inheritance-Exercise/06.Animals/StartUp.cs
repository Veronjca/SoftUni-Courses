using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType; 

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] arguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                int age = int.Parse(arguments[1]);
                string gender = arguments[2];

                switch (animalType)
                {
                    case "Dog":
                        {
                            Dog dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;
                        }

                    case "Cat":
                        {
                            Cat cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;
                        }

                    case "Kitten":
                        {
                            Kitten kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        }

                    case "Frog":
                        {
                            Frog frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;
                        }

                    case "Tomcat":
                        {
                            Tomcat tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                        }
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
