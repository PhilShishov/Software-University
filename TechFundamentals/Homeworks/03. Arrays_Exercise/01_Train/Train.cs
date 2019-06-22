
namespace P01_Train
{
    using System;
    using System.Linq;

    class Train
    {
        static void Main()
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] peopleArray = new int[wagons];

            for (int i = 0; i < wagons; i++)
            {
                int people = int.Parse(Console.ReadLine());
                peopleArray[i] = people;
            }
            for (int i = 0; i < peopleArray.Length; i++)
            {
                Console.Write(peopleArray[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"{peopleArray.Sum()}");
        }
    }
}
