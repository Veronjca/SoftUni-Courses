using System;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    ReadNumber(1, 100);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    i = 0;
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException ex)
                {
                    i = 0;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception error)
                {
                    i = 0;
                    Console.WriteLine(error.Message);
                }
            }
        }

        private static void ReadNumber(int start, int end)
        {
            string number = Console.ReadLine();
            if (!int.TryParse(number, out _))
            {
                throw new ArgumentException("Invalid number!Please start again!");
            }
            if (int.Parse(number) < start || int.Parse(number) > end)
            {
                throw new ArgumentOutOfRangeException($"Number should be between {start} - {end}!Please start again!", new ArgumentOutOfRangeException());
            }
        }
    }
}
