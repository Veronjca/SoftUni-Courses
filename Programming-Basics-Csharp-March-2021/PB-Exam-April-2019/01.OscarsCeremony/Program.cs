using System;

namespace PBExamApril2019
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double statuettes = rent - rent * 0.3;
            double catering = statuettes - statuettes * 0.15;
            double sound = catering / 2;

            double total = rent + statuettes + catering + sound;

            Console.WriteLine($"{total:F2}");
        }
    }
}
