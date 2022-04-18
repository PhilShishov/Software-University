namespace Heroes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private IList<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count;

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            var hero = this.heroes.FirstOrDefault(h => h.Name == name);

            this.heroes.Remove(hero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            var hero = this.heroes.OrderByDescending(h => h.Item.Strength).FirstOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var hero = this.heroes.OrderByDescending(h => h.Item.Ability).FirstOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var hero = this.heroes.OrderByDescending(h => h.Item.Intelligence).FirstOrDefault();

            return hero;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
