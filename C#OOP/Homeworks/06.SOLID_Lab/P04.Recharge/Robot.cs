namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;

        public Robot(string id, int capacity) 
            : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower { get; set; }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }

        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }
    }
}