using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombParameters = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int bombNumber = bombParameters[0];
            int power = bombParameters[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    if (power <= 0)
                    {
                        numbers.RemoveAll(x => x == bombNumber);
                        continue;
                    }

                    if (i - power < 0)
                    {
                        for (int j = 0; j <= i + power; j++)
                        {
                            numbers.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int j = i - power; j <= i + power; j++)
                        {
                            if (i - power >= numbers.Count)
                            {
                                break;
                            }

                            numbers.RemoveAt(i - power);
                        }
                    }

                }
            }
            int sum = numbers.Sum();

            Console.WriteLine(sum);

            // РЕШЕНИЕ НА КОЛЕГА

            //List<int> listInt = Console.ReadLine().Split().Select(int.Parse).ToList();

            //List<int> bombEffect = Console.ReadLine().Split().Select(int.Parse).ToList();


            //while (listInt.Contains(bombEffect[0]))
            //{
            //    int bombIndex = listInt.FindIndex(x => x == bombEffect[0]);
            //    int leftAoE = bombEffect[1];
            //    int rightAoE = bombEffect[1];
            //    if (bombIndex - bombEffect[1] < 0)
            //    {
            //        leftAoE = bombIndex;
            //    }
            //    else if (bombIndex + bombEffect[1] >= listInt.Count)
            //    {
            //        rightAoE = listInt.Count - 1 - bombIndex;
            //    }
            //    listInt.RemoveRange(bombIndex - leftAoE, leftAoE + rightAoE + 1);

            //}
            //int sum = listInt.Sum();
            //Console.WriteLine(sum);

        }
    }
}
