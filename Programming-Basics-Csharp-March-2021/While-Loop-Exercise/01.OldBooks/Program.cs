using System;

namespace WhileLoopExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string neededBook = Console.ReadLine();

            string currentBook = Console.ReadLine();
            int booksQuantity = 0;

            while (currentBook != "No More Books")
            {
                if (currentBook != neededBook)
                {
                    booksQuantity++;
                }
                if (currentBook == neededBook)
                {
                    Console.WriteLine($"You checked {booksQuantity} books and found it.");
                    return;
                }
                currentBook = Console.ReadLine();
            }

            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {booksQuantity} books.");
        }
    }
}
