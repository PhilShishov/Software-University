namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books.Sort(new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose()
            {
                this.books = null;
            }

            public bool MoveNext()
            {
                this.currentIndex = this.currentIndex + 1;
                bool result = currentIndex < this.books.Count;
                return result;
            }

            public void Reset() => this.currentIndex = -1;

            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;
        }
    }

}
