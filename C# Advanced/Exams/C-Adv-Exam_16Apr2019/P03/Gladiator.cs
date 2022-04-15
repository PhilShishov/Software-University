namespace FightingArena
{
    using System.Text;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetWeaponPower()
        {
            int sum = this.Weapon.Size + this.Weapon.Sharpness + this.Weapon.Solidity;

            return sum;
        }

        public int GetStatPower()
        {
            int sum = this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + this.Stat.Skills + this.Stat.Strength;

            return sum;
        }

        public int GetTotalPower()
        {
            int sum = GetWeaponPower() + GetStatPower();

            return sum;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.GetTotalPower()}");
            sb.AppendLine($"Weapon Power: {this.GetWeaponPower()}");
            sb.AppendLine($"Stat Power: {this.GetStatPower()}");

            return sb.ToString().TrimEnd();
        }
    }
}
