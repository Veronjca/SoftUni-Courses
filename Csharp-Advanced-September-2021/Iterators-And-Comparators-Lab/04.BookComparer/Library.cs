using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public readonly SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private SortedSet<Book> books;
            private int Index;
            public void Dispose() { }

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new SortedSet<Book>(books, new BookComparator());

            }
            public bool MoveNext()
            {
                return ++Index < books.Count;
            }

            public void Reset()
            {
                Index = -1;
            }
            public Book Current => books.ToList()[Index];

            object IEnumerator.Current => Current;

        }
    }
}
