using System;

namespace _06.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person correctPerson = new Person("Veronica", "Goranova", 23);

            try
            {
                Person personWithoutFirstName = new Person(null, "Penev", 30);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Person personWithoutLastName = new Person("Emre", null, 21);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Person personWithNegativeAge = new Person("Maxim", "Dimitrov", -1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Person personWithTooBigAge = new Person("Martin", "Dimitrov", 122);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Student student = new Student("P3t3r", "peter@abv.bg");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
