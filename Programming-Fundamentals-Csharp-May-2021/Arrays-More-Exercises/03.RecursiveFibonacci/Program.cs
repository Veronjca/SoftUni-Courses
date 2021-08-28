using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int[] array = new int[input];
            

            if (input == 1 || input == 2)
            {
                Console.WriteLine(1);
            }
            
            else
            {
                array[0] = 1;
                array[1] = 1;
                for (int i = 2; i < array.Length; i++)
                {
                    array[i] = array[i - 1] + array[i - 2];

                }

                Console.WriteLine(array[input - 1]);
            }

          
        }
    }
}
