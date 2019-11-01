using System;

namespace FerrariInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            ICar ferrari = new Ferrari(name);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
