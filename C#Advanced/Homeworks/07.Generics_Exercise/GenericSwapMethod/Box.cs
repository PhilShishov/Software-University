namespace GenericSwapMethod
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Box<T>
    {
        public Box()
        {
            this.Data = new List<T>();
        }

        public List<T> Data { get; private set; }

        public void Add(T element)
        {
            this.Data.Add(element);
        }        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in this.Data)
            {
              sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
