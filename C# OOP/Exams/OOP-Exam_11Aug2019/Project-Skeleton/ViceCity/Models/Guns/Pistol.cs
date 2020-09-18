namespace ViceCity.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Pistol : Gun
    {
        private const int INITIAL_BULLETS = 10;
        private const int INITIAL_TOTAL_BULLETS = 100;

        public Pistol(string name) 
            : base(name, INITIAL_BULLETS, INITIAL_TOTAL_BULLETS)
        {

        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - 1 == 0 && this.TotalBullets > 0)
            {
                this.TotalBullets -= INITIAL_BULLETS;
                this.BulletsPerBarrel = INITIAL_BULLETS;
                return 1;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
                return 1;
            }


            return 0;
        }
    }
}
