using System;

namespace ThreeupleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] firstinput = Console.ReadLine().Split();
            string name = firstinput[0] + " " + firstinput[1];
            string address = firstinput[2];
            var town = firstinput[3];
            //.Skip(3).Take(firstinput.Length - 3).ToArray();
            var firstTuple = new Threeuple<string, string, string>(name, address, town);
            Console.WriteLine(firstTuple.ToString());

            string[] secondInput = Console.ReadLine().Split();
            string nameOfDrinker = secondInput[0];
            int liters = int.Parse(secondInput[1]);
            bool isDrunk = secondInput[2] == "drunk" ? true : false;
            var secondTuple = new Threeuple<string, int, bool>(nameOfDrinker, liters, isDrunk);
            Console.WriteLine(secondTuple.ToString());

            string[] thirdInput = Console.ReadLine().Split();
            string anotherName = thirdInput[0];
            double balance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            var thirdTuple = new Threeuple<string, double, string>(anotherName, balance, bankName);
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
