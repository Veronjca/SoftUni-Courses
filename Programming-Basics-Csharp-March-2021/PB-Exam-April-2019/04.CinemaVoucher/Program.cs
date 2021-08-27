using System;

namespace CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            double voucher = double.Parse(Console.ReadLine());
            string purchase = Console.ReadLine();

            double price = 0;
            int tickets = 0;
            int other = 0;

            while (purchase != "End")
            {
                if (purchase.Length > 8)
                {
                    double index1 = (char)purchase[0];
                    double index2 = (char)purchase[1];
                    price = index1 + index2;
                }
                else
                { 
                    price = (char)purchase[0];
                }

                if (price > voucher)
                {
                    break;
                }

                voucher -= price;

                if (purchase.Length > 8)
                {
                    tickets++;
                }
                else
                {
                    other++;
                }

                purchase = Console.ReadLine();
            }

            Console.WriteLine(tickets);
            Console.WriteLine(other);
        }
    }
}
