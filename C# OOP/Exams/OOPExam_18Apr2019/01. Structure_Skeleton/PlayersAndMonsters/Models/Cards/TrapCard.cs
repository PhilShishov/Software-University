namespace PlayersAndMonsters.Models.Cards
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class TrapCard : Card
    {
        private const int INITIAL_DAMAGE = 120;
        private const int INITIAL_HP = 5;

        public TrapCard(string name)
            : base(name, INITIAL_DAMAGE, INITIAL_HP)
        {
        }
    }
}
