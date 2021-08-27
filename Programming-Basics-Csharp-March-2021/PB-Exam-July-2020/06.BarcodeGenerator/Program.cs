using System;

namespace BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            string firstNumber = firstNum.ToString();
            string secondNumber = secondNum.ToString();

            for (int i = int.Parse(firstNumber[0].ToString()); i <= int.Parse(secondNumber[0].ToString()); i++)
            {
                for (int j = int.Parse(firstNumber[1].ToString()); j <= int.Parse(secondNumber[1].ToString()); j++)
                {
                    for (int k = int.Parse(firstNumber[2].ToString()); k <= int.Parse(secondNumber[2].ToString()); k++)
                    {
                        for (int h = int.Parse(firstNumber[3].ToString()); h <= int.Parse(secondNumber[3].ToString()); h++)
                        {
                            if (i % 2 != 0)
                            {
                                if (j % 2 != 0)
                                {
                                    if (k % 2 != 0)
                                    {
                                        if (h % 2 != 0)
                                        {
                                            Console.Write($"{i}{j}{k}{h} ");
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
}
