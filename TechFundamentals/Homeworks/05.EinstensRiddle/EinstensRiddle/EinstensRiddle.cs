
namespace EinstensRiddle
{
    using System;

    class EinstensRiddle
    {
        static string[] houses = { "Red", "Green", "Yellow", "White", "Blue" };
        static string[] pets = { "Dog", "Cat", "Bird", "Fish", "Horse" };
        static string[] nationalities = { "Brit", "Swede", "Dane", "Norwegian", "German" };
        static string[] cigarettes = { "Blend", "Prince", "Dunhill", "BlueMaster", "PullMall" };
        static string[] drinks = { "Tea", "Coffee", "Milk", "Beer", "Water" };
        static string[] hints = new string[15];

        static void Main()
        {
            Random rand = new Random();
            Shuffle(rand);
            GenerateHints();
            Console.WriteLine("Einstein's riddle");
            Console.WriteLine("The situation:");
            Console.WriteLine("     1.There are 5 houses in five different colors.");
            Console.WriteLine("     2.In each house lives a person with a different nationality.");
            Console.WriteLine("     3.These five owners drink a certain type of beverage, smoke a certain brand of cigar and keep a certain pet.");
            Console.WriteLine("     4.No owners have the same pet, smoke the same brand of cigar or drink the same beverage.");

            Console.WriteLine($"The question is: Who owns the {pets[3]}?");
            Console.WriteLine("HINTS:");

            for (int i = 1; i <= hints.Length; i++)
            {
                Console.WriteLine($"{i}. {hints[i -1]}");
            }

            Console.WriteLine("Einstein wrote this riddle this century. He said that 98% of the world could not solve it.");
            Console.WriteLine("To see the solution type solution");

            string solution = Console.ReadLine();

            while (solution.ToLower() != "solution")
            {
                Console.WriteLine("Wrong command! Try again!");
                solution = Console.ReadLine();
            }

            PrintSolution();

        }

        private static void PrintSolution()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"In the {houses[i]} lives the {nationalities[i]}. He drinks {drinks[i]}, " +
                    $"smokes {cigarettes[i]} and has {pets[i]} as a pet.");
            }
        }

        private static void GenerateHints()
        {
            hints[0] = $"the {nationalities[0]} lives in the {houses[0]} house";
            hints[1] = $"the {nationalities[1]} keeps {pets[0]} as pets";
            hints[2] = $"the {nationalities[2]} drinks {drinks[0]}";
            hints[3] = $"the {houses[1]} house is on the left of the {houses[3]} house";
            hints[4] = $"the {houses[1]} house's owner drinks {drinks[1]}";
            hints[5] = $"the person who smokes {cigarettes[4]} rears {pets[2]}";
            hints[6] = $"the owner of the {houses[2]} house smokes {cigarettes[2]}";
            hints[7] = $"the man living in the center house drinks {drinks[2]}";
            hints[8] = $"the {nationalities[3]} lives in the first house";
            hints[9] = $"the man who smokes {cigarettes[0]} lives next to the one who keeps {pets[1]}";
            hints[10] = $"the man who keeps {pets[4]} lives next to the man who smokes {cigarettes[2]}";
            hints[11] = $"the owner who smokes {cigarettes[3]} drinks {drinks[3]}";
            hints[12] = $"the {nationalities[4]} smokes {cigarettes[1]}";
            hints[13] = $"the {nationalities[3]} lives next to the {houses[4]} house";
            hints[14] = $"the man who smokes {cigarettes[0]} has a neighbor who drinks {drinks[4]}";
        }

            //the Brit lives in the red house
            //the Swede keeps dogs as pets
            //the Dane drinks tea
            //the green house is on the left of the white house
            //the green house's owner drinks coffee
            //the person who smokes Pall Mall rears birds
            //the owner of the yellow house smokes Dunhill
            //the man living in the center house drinks milk
            //the Norwegian lives in the first house
            //the man who smokes blends lives next to the one who keeps cats
            //the man who keeps horses lives next to the man who smokes Dunhill
            //the owner who smokes BlueMaster drinks beer
            //the German smokes Prince
            //the Norwegian lives next to the blue house
            //the man who smokes blend has a neighbor who drinks water

        private static void Shuffle(Random rand)
        {
            for (int i = 0; i < 5; i++)
            {
                //Shuffling houses
                int randomHouseOne = rand.Next(0, houses.Length);
                int randomHouseTwo = rand.Next(0, houses.Length);
                Swap(randomHouseOne, randomHouseTwo, houses);

                //Shuffling pets
                int randomPetOne = rand.Next(0, pets.Length);
                int randomPetTwo = rand.Next(0, pets.Length);
                Swap(randomPetOne, randomPetTwo, pets);

                //Shuffling Nationalities
                int randomNationalityOne = rand.Next(0, nationalities.Length);
                int randomNationalityTwo = rand.Next(0, nationalities.Length);
                Swap(randomNationalityOne, randomNationalityTwo, nationalities);

                //Shuffling cigarettes
                int randomCigaretteOne = rand.Next(0, cigarettes.Length);
                int randomCigaretteTwo = rand.Next(0, cigarettes.Length);
                Swap(randomCigaretteOne, randomCigaretteTwo, cigarettes);

                //Shuffling drinks
                int randomDrinkOne = rand.Next(0, drinks.Length);
                int randomDrinkTwo = rand.Next(0, drinks.Length);
                Swap(randomDrinkOne, randomDrinkTwo, drinks);
            }
        }

        private static void Swap(int randomOne, int randomTwo, string[] category)
        {
            string temp = category[randomOne];
            category[randomOne] = category[randomTwo];
            category[randomTwo] = temp;
        }
    }
}
