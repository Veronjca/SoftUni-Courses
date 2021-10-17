using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public List<T> Elements { get; set; } = new List<T>();

        public void Push(T element)
        {
            Elements.Insert(0, element);
        }

        public void Pop()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("No elements");
                return;
            }
            Elements.RemoveAt(0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
