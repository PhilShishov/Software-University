namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Advanced: Player
    {
        private const int INITIAL_HP = 250;

        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, INITIAL_HP)
        {
        }
    }
}
