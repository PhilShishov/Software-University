using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstinput = Console.ReadLine().Split();
            string name = firstinput[0] + " " + firstinput[1];
            string address = firstinput[2];
            var firstTuple = new MyTuple<string, string>(name, address);
            Console.WriteLine(firstTuple.ToString());

            string[] secondInput = Console.ReadLine().Split();
            string nameOfDrinker = secondInput[0];
            int liters = int.Parse(secondInput[1]);
            var secondTuple = new MyTuple<string, int>(nameOfDrinker, liters);
            Console.WriteLine(secondTuple.ToString());

            string[] thirdInput = Console.ReadLine().Split();
            int num1 = int.Parse(thirdInput[0]);
            double num2 = double.Parse(thirdInput[1]);
            var thirdTuple = new MyTuple<int, double>(num1, num2);
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
