namespace Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MyTuple<TItem1, TItem2>
    {
        private readonly TItem1 item1;
        private readonly TItem2 item2;

        public MyTuple(TItem1 item1, TItem2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }       

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
