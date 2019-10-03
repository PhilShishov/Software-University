namespace ViceCity.Models.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class CivilPlayer : Player
    {
        private const int INITIAL_HP = 50;

        public CivilPlayer(string name) 
            : base(name, INITIAL_HP)
        {
        }
    }
}
