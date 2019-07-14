
namespace P06_TribitSwitch
{
    using System;

    class TribitSwitch
    {
        static void Main()
        {
            string inputN = Console.ReadLine();
            int numberN = int.Parse(inputN);
            string inputP = Console.ReadLine();
            int numberP = int.Parse(inputP);

            int mask = 7 << numberP;
            int result = numberN ^ mask;

            Console.WriteLine(result);
        }
    }
}
