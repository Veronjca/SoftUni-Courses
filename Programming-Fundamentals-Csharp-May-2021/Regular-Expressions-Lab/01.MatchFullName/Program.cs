using System;
using System.Text.RegularExpressions;

namespace RegExLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\b[A-Z][a-z]+ [A-Z][a-z]+)";

            string input = Console.ReadLine();

            Regex findFullNames = new Regex(pattern);

            MatchCollection allMatches = findFullNames.Matches(input);

           
                Console.WriteLine(string.Join(" ", allMatches));
            
        }
    }
}
