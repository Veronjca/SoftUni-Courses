using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(params int[] numbers)
        {
            this.StoneNumbers = numbers.ToList();
        }
        public List<int> StoneNumbers { get; set; }

        public List<int> Rearrange()
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < this.StoneNumbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    temp.Add(this.StoneNumbers[i]);
                }             
            }

            for (int i = this.StoneNumbers.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    temp.Add(this.StoneNumbers[i]);
                }
            }

            return temp;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new Iterator(Rearrange());
        }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class Iterator : IEnumerator<int>
        {
            private int index;
            public Iterator(List<int> numbers)
            {
                this.Reset();
                this.StoneNumbers = numbers;
            }
            public List<int> StoneNumbers { get; private set; }

            public int Current => this.StoneNumbers[index];

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++this.index < this.StoneNumbers.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
