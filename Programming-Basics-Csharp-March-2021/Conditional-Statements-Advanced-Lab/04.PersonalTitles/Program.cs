﻿using System;

namespace PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (age >=16 && gender == "m")
            {
                Console.WriteLine("Mr.");
            }
            else if ( age < 16 && gender == "m")
            {
                Console.WriteLine("Master");
            }

            if (age >=16 && gender == "f")
            {
                Console.WriteLine("Ms.");
            }
            else if (age < 16 && gender == "f")
            {
                Console.WriteLine("Miss"); 
            }
        }
    }
}
