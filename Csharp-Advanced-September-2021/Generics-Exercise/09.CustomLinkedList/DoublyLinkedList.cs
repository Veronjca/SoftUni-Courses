using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList
    {
        private LinkedListItem first = null;
        private LinkedListItem last = null;

        public int Count { get; private set; }

        // get count with recursion
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

        public void AddFirst(int number)
        {
            LinkedListItem currentItem = new LinkedListItem(number);
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

        public void AddLast(int number)
        {
            LinkedListItem currentItem = new LinkedListItem(number);
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

        public int RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }

            int currentFirstValue = first.Value;

            if (first == last)//when collection have only 1 element
            {
                first = null;
                last = null;
                Count--;
            }
            else
            {
                LinkedListItem newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
                Count--;
            }
            return currentFirstValue;
        }

        public int RemoveLast()
        {
            if (last == null)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }
            int currentLast = last.Value;

            if (first == last)//when collection have only 1 element
            {
                first = null;
                last = null;
                Count--;
            }
            else
            {
                LinkedListItem newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
                Count--;
            }

            return currentLast;
        }

        public void ForEach (Action<int> action)
        {
            int[] array = ToArray();

            foreach (var item in array)
            {
                action(item);
            }
        }
        public int[] ToArray()
        {
            int[] array = new int[Count];

            LinkedListItem current = first;
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
