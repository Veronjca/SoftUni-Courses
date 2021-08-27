using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            

            int salaryLeft = salary;

            for (int i = 0; i < openTabs; i++)
            {
                string websiteName = Console.ReadLine();

                if (websiteName == "Facebook")
                {
                    salaryLeft -= 150;
                }
                if (websiteName == "Instagram")
                {
                    salaryLeft -= 100;
                }
                if (websiteName == "Reddit")
                {
                    salaryLeft -= 50;
                }

                if (salaryLeft <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }

            if (salaryLeft > 0)
            {
                Console.WriteLine(salaryLeft);
            }
            

            
        }
    }
}
