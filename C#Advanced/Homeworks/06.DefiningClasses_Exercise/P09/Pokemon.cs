namespace P09
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pokemon
    {
        private string pokemonName;
        private string pokemonElement;
        private int pokemonHealth;

        public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.PokemonName = pokemonName;
            this.PokemonElement = pokemonElement;
            this.PokemonHealth = pokemonHealth;
        }

        public string PokemonName
        {
            get { return pokemonName; }
            set { pokemonName = value; }
        }

        public string PokemonElement
        {
            get { return pokemonElement; }
            set { pokemonElement = value; }
        }

        public int PokemonHealth
        {
            get { return pokemonHealth; }
            set { pokemonHealth = value; }
        }
    }
}
