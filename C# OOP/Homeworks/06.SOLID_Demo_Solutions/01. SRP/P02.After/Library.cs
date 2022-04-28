namespace P02.After
{
    using System.Collections.Generic;

    public class Library
    {
        private List<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }

        //private IEnumerable<Book> books;

        //public Library(IEnumerable<Book> books)
        //{
        //    this.books = books;
        //}

        public int FindBook(string title)
        {
            //Logic
            return 42;
        }
    }
}
