namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList<T> : List<T>
    {
        private Random rand;

        public RandomList()
        {
            this.rand = new Random();
        }

        public T RemoveRandomElement()
        {
            int index = rand.Next(0, this.Count);

            T element = this[index];

            this.RemoveAt(index);

            return element;
        }
    }

    //public class RandomList : List<string>
    //{
    //    public string RandomString()
    //    {
    //        Random random = new Random();
    //        int index = random.Next(0, this.Count);
    //        string randomString = this[index];
    //        this.Remove(randomString);
    //        return randomString;
    //    }
    //}
}
