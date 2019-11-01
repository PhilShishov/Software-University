using System;

namespace P05_GreedyTimes
{

    public class StartUp
    {
        static Bag bag;

        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] save = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bag = new Bag();
            bag.FillBag(save, bagCapacity);

            Console.WriteLine(bag);            
        }
    }
}