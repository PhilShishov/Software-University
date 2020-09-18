namespace PlayersAndMonsters.Models.Cards
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MagicCard : Card
    {
        private const int INITIAL_DAMAGE = 5;
        private const int INITIAL_HP = 80;

        public MagicCard(string name) 
            : base(name, INITIAL_DAMAGE, INITIAL_HP)
        {
        }
    }
}
