
namespace P01_BakingMasterclass
{
    using System;

    class BakingMasterclass
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFlour = double.Parse(Console.ReadLine());
            double priceEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine());

            int studentsMore = (int)(Math.Ceiling(students + 0.20 * students));

            int freeFlour = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    freeFlour++;
                }
            }

            double neededMoney = (priceApron * studentsMore) + (priceEgg * 10 * students) + priceFlour * (students - freeFlour);

            if (neededMoney > budget)
            {
                Console.WriteLine($"{neededMoney - budget:F2}$ more needed.");
            }
            else
            {
                Console.WriteLine($"Items purchased for {neededMoney:F2}$.");
            }
        }
    }
}
