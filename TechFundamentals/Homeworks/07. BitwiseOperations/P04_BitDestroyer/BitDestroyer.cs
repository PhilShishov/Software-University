
namespace P04_BitDestroyer
{
    using System;

    class BitDestroyer
    {
        static void Main()
        {
            string inputN = Console.ReadLine();
            int numberN = int.Parse(inputN);
            string inputP = Console.ReadLine();
            int numberP = int.Parse(inputP);

            int mask = 1 << numberP;
            int invertMask = ~mask;

            int result = numberN & invertMask;

            Console.WriteLine(result);
        }
    }
}
