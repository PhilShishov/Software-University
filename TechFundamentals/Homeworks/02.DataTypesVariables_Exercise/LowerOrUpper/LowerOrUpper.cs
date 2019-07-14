
namespace LowerOrUpper
{
    using System;

    class LowerOrUpper
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            bool isUpper = char.IsUpper(letter);
            bool isLower = char.IsLower(letter);

            if (isUpper)
            {
                Console.WriteLine("upper-case");
            }
            else if (isLower)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
