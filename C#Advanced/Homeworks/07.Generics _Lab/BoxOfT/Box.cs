namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            if (this.Count > 0)
            {
                T last = this.data.Last();
                this.data.RemoveAt(Count - 1);

                return last;
            }

            throw new InvalidOperationException("Cannot remove element from empty collection");

        }
    }
}
