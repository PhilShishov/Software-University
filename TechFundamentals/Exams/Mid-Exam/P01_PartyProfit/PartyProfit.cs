
namespace P01_PartyProfit
{
    using System;

    class PartyProfit
    {
        static void Main()
        {
            int companions = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int coins = days * 50;

            for (int i = 1; i <= days; i++)
            {
                if (i % 10 == 0)
                {
                    companions -= 2;
                }
                if (i % 15 == 0)
                {
                    companions += 5;
                    coins -= 2 * companions;
                }

                if (i % 3 == 0)
                {
                    coins -= 3 * companions;
                }
                if (i % 5 == 0)
                {
                    coins += 20 * companions;
                }
                coins -= 2 * companions;
            }

            Console.WriteLine($"{companions} companions received {coins / companions} coins each.");
        }
    }
}