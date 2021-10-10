using System;

namespace CustomLinkedList
{
    public class StartUp
    {
       public static void Main(string[] args)
        {            

            var list = new DoublyLinkedList<int>();
            list.AddFirst(3);
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 3
            list.AddFirst(2);
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 2-3
            list.AddFirst(1);
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 1-2-3
            list.AddLast(4);
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 1-2-3-4
            list.AddFirst(0);
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 0-1-2-3-4
            list.AddLast(100);
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 0-1-2-3-4-100
            list.RemoveFirst();
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 1-2-3-4-100
            list.RemoveLast();
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 1-2-3-4
            list.AddLast(5);
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 1-2-3-4-5

            list.ForEach(x => Console.WriteLine("--" + x));
        }
    }
}
