
namespace P01_ReverseStrings
{
    using System;

    class ReverseStrings
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string reversed = "";

                for (int i = input.Length -1; i >= 0; i--)
                {
                    reversed += input[i];
                }

                Console.WriteLine($"{input} = {reversed}");
            }
        }
    }
}
