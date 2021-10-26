using System;

namespace Farm
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();

            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}
