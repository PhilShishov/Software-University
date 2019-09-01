namespace AquariumAdventure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Size { get; set; }

        public void Add(Fish fish)
        {
            //Possible error
            if (!this.fishInPool.Any(f => f.Name == fish.Name) && this.fishInPool.Count < this.Capacity)
            {
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            var isRemoved = false;
            var fish = this.fishInPool.FirstOrDefault(f => f.Name == name);

            if (fish != null)
            {
                this.fishInPool.Remove(fish);
                isRemoved = true;
            }

            return isRemoved;
        }

        public Fish FindFish(string name)
        {
            Fish fish = this.fishInPool.FirstOrDefault(f => f.Name == name);

            if (fish == null)
            {
                fish = null;
            }

            return fish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine($"Aquarium Info:");
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in this.fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
