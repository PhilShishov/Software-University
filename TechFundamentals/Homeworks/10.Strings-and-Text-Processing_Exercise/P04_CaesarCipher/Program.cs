
namespace P04_CaesarCipher
{
    using System;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var result = string.Empty;

            foreach (var c in input)
            {
                var shifted = (char)(c + 3);
                result += shifted;
            }
           
            Console.WriteLine(result);
        }
    }
}
