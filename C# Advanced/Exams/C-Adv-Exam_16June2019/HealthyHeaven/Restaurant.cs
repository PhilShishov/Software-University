namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public string Name { get; private set; }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            bool isBought = false;
            var salad = this.data.FirstOrDefault(s => s.Name == name);

            if (salad != null)
            {
                isBought = true;
                this.data.Remove(salad);
            }

            return isBought;
        }

        public Salad GetHealthiestSalad()
        {
            var salad = this.data.OrderBy(s => s.GetTotalCalories()).FirstOrDefault();

            return salad;
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var salad in this.data)
            {
                sb.AppendLine(salad.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
