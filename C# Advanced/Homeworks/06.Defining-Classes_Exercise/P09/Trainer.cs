namespace P09
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Trainer
    {
        private const int DefaultBadgeNumbers = 0;
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name)

        {
            this.Name = name;
            this.NumberOfBadges = DefaultBadgeNumbers;
            this.Pokemons = new List<Pokemon>();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }
    }
}
