using System;
using System.Linq;

namespace ArraysMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            int[] result = new int[numberOfStrings];


            for (int i = 0; i < numberOfStrings; i++)
            {
                string word = Console.ReadLine();
                int sum = 0;

                for (int j = 0; j < word.Length; j++)
                {

                    if (word[j] == 97 || word[j] == 101 || word[j] == 105 || word[j] == 111 || word[j] == 117 || word[j] == 65 || word[j] == 69 || word[j] == 73 || word[j] == 79 || word[j] == 85)
                    {
                        sum += word[j] * word.Length;
                    }
                    else
                    {
                        sum += word[j] / word.Length;
                    }


                }

                result[i] = sum;
            }

            Array.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }



        }
    }
}
