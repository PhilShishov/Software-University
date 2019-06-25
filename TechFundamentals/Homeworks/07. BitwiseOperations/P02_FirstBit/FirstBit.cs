
namespace P02_FirstBit
{
    using System;

    class FirstBit
    {
        static void Main()
        {
            string inputN = Console.ReadLine();
            int numberN = int.Parse(inputN);

            int shiftedNumber = numberN >> 1;
            int result = shiftedNumber & 1;

            Console.WriteLine(result);
        }
    }
}
