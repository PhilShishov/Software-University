
namespace P03_PthBit
{
    using System;

    class PthBit
    {
        static void Main()
        {
            string inputN = Console.ReadLine();
            int numberN = int.Parse(inputN);
            string inputP = Console.ReadLine();
            int numberP = int.Parse(inputP);

            int shiftedNumber = numberN >> numberP;
            int result = shiftedNumber & 1;

            Console.WriteLine(result);
        }
    }
}
