
namespace TownInfo
{
    using System;

    class TownInfo
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");

        }
    }
}
