namespace SpaceStation.Models.Bags
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Backpack : IBag
    {
        public Backpack()
        {
            this.Items = new List<string>();
        }
        public ICollection<string> Items { get; private set; }

    }
}
