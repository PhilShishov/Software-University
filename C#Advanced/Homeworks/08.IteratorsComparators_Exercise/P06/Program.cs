
namespace P06
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                var person = new Person(name, age);

                //Console.WriteLine(person.GetHashCode());

                sortedSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
