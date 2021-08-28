using System;
using System.Linq;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isTheLengthValid = ValidLength(password);
            bool ifConsistLetters = ConsistLetters(password);
            int ifConsistTwoDigits = ConsistDigits(password);
            bool ifConsistOtherElements = ConsistOtherElements(password);


            if (isTheLengthValid && ifConsistLetters && ifConsistTwoDigits >= 2 && !ifConsistOtherElements)
            {
                Console.WriteLine("Password is valid");
            }
            if (isTheLengthValid == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (ifConsistOtherElements == true)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (ifConsistTwoDigits < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
;

        }

        private static bool ConsistOtherElements(string password)
        {
            bool ifConsistOtherElements = true;

            for (int i = 0; i < password.Length; i++)
            {
                bool ifDigit = int.TryParse(password[i].ToString(), out _);

                if (password[i] >= 65 && password[i] <= 90 || password[i] >= 97 && password[i] <= 122)
                {
                    ifConsistOtherElements = false;
                }               
                else if (ifDigit)
                {
                    ifConsistOtherElements = false;
                }
                else
                {
                    ifConsistOtherElements = true;
                    break;
                }
            }

            return ifConsistOtherElements;
        }

        private static int ConsistDigits(string password)
        {
            bool ifDigit = false;
            int counter = 0;
            

            for (int i = 0; i < password.Length; i++)
            {
                ifDigit = int.TryParse(password[i].ToString(), out _);
                if (ifDigit)
                {
                    counter++;
                }
            }

            return counter;
            
        }

        private static bool ValidLength(string password)
        {
            bool validLength = false;
            if (password.Length >= 6 && password.Length <= 10)
            {
                validLength = true;
            }

            return validLength;
        }

        private static bool ConsistLetters(string password)
        {
            bool isLetter = false;
           
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 65 && password[i] <= 90 || password[i] >= 97 && password[i] <= 122)
                {
                    isLetter = true;
                }

            }

            return isLetter;

        }
    }
}



