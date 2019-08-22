namespace GenericCountMethod
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Box<TItem>
        where TItem : IComparable<TItem>
    {

        private List<TItem> items;

        public Box()
        {
            this.items = new List<TItem>();
        }

        public int Count { get; private set; }

        public void Add(TItem item)
        {
            this.items.Add(item);
        }

        public int Compare(TItem item)
        {
            foreach (var currenItem in this.items)
            {
                if (currenItem.CompareTo(item) > 0)
                {
                    this.Count++;
                }
            }
            return this.Count;
        }
    }
}
