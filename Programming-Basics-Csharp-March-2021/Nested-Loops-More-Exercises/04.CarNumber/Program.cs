using System;

namespace CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginning = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());


            //Ако номерът започва с четна цифра, то той трябва да завършва на нечетна цифра и обратното
            //– ако започва с нечетна, завършва на четна
            //Първата цифра от номера е по-голяма от последната
            //Сумата от втората и третата цифра трябва да е четно число

            for (int i = beginning; i <= end; i++)
            {
                for (int j = beginning; j <= end; j++)
                {
                    for (int k = beginning; k <= end; k++)
                    {
                        for (int l = beginning; l <= end; l++)
                        {
                            int sum = j + k;

                            if (i > l)
                            {
                                if (sum % 2 == 0)
                                {
                                    if (i % 2 == 0 && l % 2 != 0)
                                    {

                                        Console.Write($"{i}{j}{k}{l} ");
                                        continue;

                                    }
                                    else if (i % 2 != 0 && l % 2 == 0)
                                    {
                                        Console.Write($"{i}{j}{k}{l} ");
                                        continue;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
