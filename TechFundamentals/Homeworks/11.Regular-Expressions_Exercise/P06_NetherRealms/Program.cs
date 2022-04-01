
namespace P06_NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string[] demons = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var demonHealths = new SortedDictionary<string, int>();
            var demonDamages = new SortedDictionary<string, double>();

            var pattern = @"-?\d+\.?\d*";
            var regex = new Regex(pattern);

            foreach (var demon in demons)
            {
                var health = demon
                    .Where(s => !char.IsDigit(s)
                    && s != '+' && s != '-' && s != '*' && s != '/' && s != '.')
                    .Sum(s => (int)s);

                demonHealths[demon] = health;

                var matches = regex.Matches(demon);

                var damage = 0.0;

                foreach (Match match in matches)
                {
                    var value = match.Value;
                    damage += double.Parse(value);
                }

                foreach (var symbol in demon)
                {
                    if (symbol == '*')
                    {
                        damage *= 2;
                    }
                    else if (symbol == '/')
                    {
                        damage /= 2;
                    }
                }

                demonDamages[demon] = damage;

            }

            foreach (var demon in demonDamages)
            {
                var demonName = demon.Key;
                var demonHealth = demonHealths[demonName];
                var demonDamage = demon.Value;

                Console.WriteLine($"{demonName} - {demonHealth} health, {demonDamage:F2} damage");
            }
        }
    }
}
