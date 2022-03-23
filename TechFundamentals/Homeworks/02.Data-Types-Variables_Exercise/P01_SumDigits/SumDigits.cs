namespace P01_SumDigits
{
    using System;

    class SumDigits
    {
        static void Main(string[] args)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            //int sum = 0;

            //while (n != 0)
            //{
            //    sum += n % 10;
            //    n /= 10;
            //}
            //Console.WriteLine(sum);

            string numberAsString = Console.ReadLine();
            int sumOfDigits = 0;

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int digit = int.Parse(numberAsString[i].ToString());
                sumOfDigits += digit;
            }
            Console.WriteLine(sumOfDigits);
        }
    }
}
