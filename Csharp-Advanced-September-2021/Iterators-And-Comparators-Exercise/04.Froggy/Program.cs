using System;
using System.Linq;

namespace _04.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            lake.Rearrange();

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
