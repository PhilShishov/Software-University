namespace PlayersAndMonsters.Models.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Beginner : Player
    {
        private const int INITIAL_HP = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, INITIAL_HP)
        {
        }
    }
}
