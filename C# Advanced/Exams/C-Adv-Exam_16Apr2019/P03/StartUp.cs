
namespace FightingArena
{
    using System;
    
    public class StartUp
    {
        public static void Main()
        {
            //Creates arena
            var arena = new Arena("Armeec");

            //Creates stats
            var firstGlariatorStat = new Stat(20, 25, 35, 14, 48);
            var secondGlariatorStat = new Stat(40, 40, 40, 40, 40);
            var thirdGlariatorStat = new Stat(20, 25, 35, 14, 48);

            //Creates weapons
            var firstGlariatorWeapon = new Weapon(5, 28, 100);
            var secondGlariatorWeapon = new Weapon(5, 28, 100);
            var thirdGlariatorWeapon = new Weapon(50, 50, 50);

            //Creates gladiators
            var firstGladiator = new Gladiator("Stoyan", firstGlariatorStat, firstGlariatorWeapon);
            var secondGladiator = new Gladiator("Pesho", secondGlariatorStat, secondGlariatorWeapon);
            var thirdGladiator = new Gladiator("Gosho", thirdGlariatorStat, thirdGlariatorWeapon);

            //Adds gladiators to arena
            arena.Add(firstGladiator);
            arena.Add(secondGladiator);
            arena.Add(thirdGladiator);

            //Prints gladiators count at the arena
            Console.WriteLine(arena.Count);

            //Gets strongest gladiator and print him
            var strongestGladiator = arena.GetGladitorWithHighestTotalPower();
            Console.WriteLine(strongestGladiator);

            //Gets gladiator with the strongest weapon and print him
            var bestWeaponGladiator = arena.GetGladitorWithHighestWeaponPower();
            Console.WriteLine(bestWeaponGladiator);

            //Gets gladiator with the strongest stat and print him
            var bestStatGladiator = arena.GetGladitorWithHighestStatPower();
            Console.WriteLine(bestStatGladiator);

            //Removes gladiator
            arena.Remove("Gosho");

            //Prints gladiators count at the arena
            Console.WriteLine(arena.Count);

            //Prints the arena
            Console.WriteLine(arena);

        }
    }
}
