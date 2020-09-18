
namespace P01_BinaryDigitsCount
{
    using System;
    using System.Collections.Generic;

    class BinaryDigitsCount
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int bit = int.Parse(Console.ReadLine());
            string binary = DecToBinary(n);

            int counter = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                int currentBit = (int)char.GetNumericValue(binary[i]);

                if (bit == currentBit)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        private static string DecToBinary(int n)
        {
            List<string> binary = new List<string>();

            while (n != 0)
            {
                string res = (n % 2).ToString();
                binary.Add(res);
                n /= 2;
            }

            binary.Reverse();
            return string.Join("", binary);
        }
    }
}
