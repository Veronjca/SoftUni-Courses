using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> URLs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            bool flag;
            foreach (var number in phoneNumbers)
            {
                flag = false;
                foreach (var digit in number)
                {
                    int output = 0;
                    if (int.TryParse(digit.ToString(), out output) == false)
                    {
                        flag = true;
                        Console.WriteLine("Invalid number!");
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }
                if (number.Length == 10)
                {
                    smartphone.Call(number);
                }
                else
                {
                    stationaryPhone.Call(number);
                }
            }

            foreach (var URL in URLs)
            {
                flag = false;
                foreach (var item in URL)
                {
                    int output = 0;
                    if (int.TryParse(item.ToString(), out output) == true)
                    {
                        flag = true;
                        Console.WriteLine("Invalid URL!");
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }
                smartphone.Browse(URL);
                
            }
        }
    }
}
