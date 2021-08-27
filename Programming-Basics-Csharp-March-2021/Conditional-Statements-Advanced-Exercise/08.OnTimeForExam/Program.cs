using System;

namespace OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int difference = 0;
            int hour = 0;
            int minutes = 0;

            examMinute += examHour * 60;
            arrivalMinute += arrivalHour * 60;

            if (arrivalMinute > examMinute)
            {
                Console.WriteLine("Late");
                difference = arrivalMinute - examMinute;
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours after the start");

                }
            }
            else if (arrivalMinute < examMinute - 30)
            {
                Console.WriteLine("Early");
                difference = examMinute - arrivalMinute;
                if (difference < 60)
                {
                    Console.WriteLine($"{difference:d2} minutes before the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                difference = examMinute - arrivalMinute;
                Console.WriteLine($"{difference} minutes before the start");
            }
        }
    }
}
