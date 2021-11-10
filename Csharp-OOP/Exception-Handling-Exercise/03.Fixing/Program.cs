using System;

namespace _03.Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5];
            weekdays[0] = "Sunday";
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";

                for (int i = 0; i <= 5; i++)
                {
                    try
                    {
                        Console.WriteLine(weekdays[i].ToString());
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.ReadLine();

        }
    }
}
