namespace ViceCity.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Rifle : Gun
    {
        private const int INITIAL_BULLETS = 50;
        private const int INITIAL_TOTAL_BULLETS = 500;

        public Rifle(string name)
            : base(name, INITIAL_BULLETS, INITIAL_TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - 5 == 0 && this.TotalBullets > 0)
            {
                this.TotalBullets -= INITIAL_BULLETS;
                this.BulletsPerBarrel = INITIAL_BULLETS;
                return 5;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel -= 5;
                return 5;
            }

            return 0;
        }
    }
}
