using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"\+359(\s|-)2\1[0-9]{3}\1[0-9]{4}\b";

            string input = Console.ReadLine();

            Regex findPhoneNumber = new Regex(pattern);

            MatchCollection allPhoneNumbers = findPhoneNumber.Matches(input);

          

            Console.WriteLine(string.Join(", ", allPhoneNumbers));
        }
    }
}
