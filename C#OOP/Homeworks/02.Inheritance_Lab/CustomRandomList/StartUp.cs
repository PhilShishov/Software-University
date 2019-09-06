using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //RandomList randomList = new RandomList { "1", "2", "3", "4", "5" };
            //Console.WriteLine(randomList.RandomString());

            var randomList = new RandomList<int>();

            for (int i = 1; i < 50; i++)
            {
                randomList.Add(i);
            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(randomList.RemoveRandomElement());
            }
        }
    }
}
