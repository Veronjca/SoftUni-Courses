using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                ValidateNumber(number);
                double root = Math.Sqrt(int.Parse(number));
                Console.WriteLine(root);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number");
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }

        }

        private static void ValidateNumber(string number)
        {
            if (int.Parse(number) < 0)
            {
                throw new ArgumentException();
            }
            if (!int.TryParse(number, out _))
            {
                throw new ArgumentException();
            }
        }
    }
}
