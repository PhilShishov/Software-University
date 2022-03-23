
namespace P09_PokeMon
{
    using System;

    class PokeMon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int originalPokePower = pokePower;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int counter = 0;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                counter++;

                if (originalPokePower * 0.5 == pokePower && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;                    
                }

            }
            Console.WriteLine(pokePower);
            Console.WriteLine(counter);

        }
    }
}
