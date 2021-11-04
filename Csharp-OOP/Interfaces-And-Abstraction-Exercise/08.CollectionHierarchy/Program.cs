using System;

namespace _08.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddRemoveCollection first = new AddRemoveCollection();
            MyList second = new MyList();
            AddCollection third = new AddCollection();

            string[] wordToAdd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Add(third, wordToAdd);
            Add(first, wordToAdd);
            Add(second, wordToAdd);

            int n = int.Parse(Console.ReadLine());

            Remove(first, n);
            Remove(second, n);

        }

        private static void Remove(IRemove collection, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{collection.Remove()} ");
            }
            Console.WriteLine();
        }

        private static void Add(IAdd collection, string[] wordToAdd)
        {
            foreach (var word in wordToAdd)
            {
                Console.Write($"{collection.Add(word)} ");
            }
            Console.WriteLine();
        }
    }
}
