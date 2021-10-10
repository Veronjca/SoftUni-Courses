using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class DoublyLinkedList<T>
    {
        private LinkedListItem<T> first = null;
        private LinkedListItem<T> last = null;

        public int Count { get; private set; }

        // another way to get count 
        //public int Count
        //{
        //    get
        //    {
        //        int count = 0;

        //        LinkedListItem current = first;
        //        while (current != null)
        //        {
        //            count++;
        //            current = current.Next;
        //        }

        //        return count;
        //    }
        //}

        // Get count with recursion / GetCount(first)
        //public int GetCount(LinkedListItem<T> current)
        //{
        //    if (current == null)
        //    {
        //        return 0;
        //    }

        //    return 1 + GetCount(current.Next);
        //}
        public void AddFirst(T item)
        {
            LinkedListItem<T> currentItem = new LinkedListItem<T>(item);
            if (this.first == null )
            {
                first = currentItem;
                last = currentItem;
            }
            else
            {
                currentItem.Next = first;
                first.Previous = currentItem;
                first = currentItem;
               
            }
            Count++;
        }

        public void AddLast(T item)
        {
            LinkedListItem<T> currentItem = new LinkedListItem<T>(item);
            if (this.first == null)
            {
                first = currentItem;
                last = currentItem;
            }
            else
            {
                last.Next = currentItem;
                currentItem.Previous = last;
                last = currentItem;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }

            T currentFirstValue = first.Value;

            if (first == last)//when collection have only 1 element
            {
                first = null;
                last = null;
                Count--;
            }
            else
            {
                LinkedListItem<T> newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
                Count--;
            }
            return currentFirstValue;
        }

        public T RemoveLast()
        {
            if (last == null)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }
            T currentLast = last.Value;

            if (first == last)//when collection have only 1 element
            {
                first = null;
                last = null;
                Count--;
            }
            else
            {
                LinkedListItem<T> newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
                Count--;
            }

            return currentLast;
        }

        public void ForEach (Action<T> action)
        {
            T[] array = ToArray();

            foreach (var item in array)
            {
                action(item);
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];

            LinkedListItem<T> current = first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Value;
                current = current.Next;
                index++;
            }

            return array;
        }
    }
}
