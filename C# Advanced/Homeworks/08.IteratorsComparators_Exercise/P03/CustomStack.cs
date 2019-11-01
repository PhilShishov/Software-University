namespace P03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private Stack<T> stack;

        public CustomStack()
        {
            this.stack = new Stack<T>();
        }

        public void Push(List<T> items)
        {
            foreach (var item in items)
            {
               this.stack.Push(item);
            }
        }

        public void Pop()
        {
            if (this.stack.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            this.stack.Pop();
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var currentItem in this.stack)
            {
                yield return currentItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
