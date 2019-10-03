namespace ViceCity.Models.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MainPlayer : Player
    {
        private const int INITIAL_HP = 100;
        private const string INITIAL_NAME = "Tommy Vercetti";

        public MainPlayer() 
            : base(INITIAL_NAME, INITIAL_HP)
        {
        }
    }
}
