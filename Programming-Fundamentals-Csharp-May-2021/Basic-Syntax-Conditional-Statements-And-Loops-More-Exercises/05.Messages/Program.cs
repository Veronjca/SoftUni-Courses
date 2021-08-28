using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < count; i++)
            {
                string number = Console.ReadLine();

                int mainDigit = int.Parse(number[0].ToString());

                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                int letterIndex = offset + number.Length - 1 + 97;

                if (mainDigit == 0)
                {
                    letterIndex = 32;
                }
                message += (char)letterIndex;
            }

            Console.WriteLine(message);
        }
    }
}
