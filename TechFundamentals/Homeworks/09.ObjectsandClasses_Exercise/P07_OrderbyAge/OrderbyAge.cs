
namespace P07_OrderbyAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class OrderbyAge
    {
        public class Person
        {
            public Person(string name, int id, int age)
            {
                Name = name;
                ID = id;
                Age = age;
            }

            public string Name { get; set; }

            public int ID { get; set; }

            public int Age { get; set; }

            public override string ToString()
            {
                return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }

        static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split();

                string name = tokens[0];
                int id = int.Parse(tokens[1]);
                int age = int.Parse(tokens[2]);

                var person = new Person(name, id, age);

                people.Add(person);
            }

            foreach (Person person in people.OrderBy(p => p.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}
