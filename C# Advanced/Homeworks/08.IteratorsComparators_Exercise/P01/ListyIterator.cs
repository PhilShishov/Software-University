namespace P01
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> items)
        {
            this.items = items;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index < this.items.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.index]);
        }

        //public void PrintAll()
        //{
        //    if (this.items.Count == 0)
        //    {
        //        throw new InvalidOperationException("Invalid Operation!");
        //    }

        //    Console.WriteLine(string.Join(" ", this.items));
        //}

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var currentItem in this.items)
            {
                yield return currentItem;
            }            
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
