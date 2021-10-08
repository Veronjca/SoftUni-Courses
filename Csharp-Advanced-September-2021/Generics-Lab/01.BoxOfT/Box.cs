using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> Collection { get; set; } = new Stack<T>();
        public int Count { get; private set; }

        public void Add(T element)
        {
            Collection.Push(element);
            Count++;
        }

        public T Remove()
        {
            Count--;
            return Collection.Pop();
            
        }

    }
}
