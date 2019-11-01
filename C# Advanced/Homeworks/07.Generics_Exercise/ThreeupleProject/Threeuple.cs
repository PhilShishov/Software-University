namespace ThreeupleProject
{
    public class Threeuple<TItem1, TItem2, TItem3>
    {
        private readonly TItem1 item1;
        private readonly TItem2 item2;
        private readonly TItem3 item3;

        public Threeuple(TItem1 item1, TItem2 item2, TItem3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }      

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }
    }
}
