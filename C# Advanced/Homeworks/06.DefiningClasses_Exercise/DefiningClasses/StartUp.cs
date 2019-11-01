namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            // Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] peopleData = Console.ReadLine().Split();
                Person person = new Person(peopleData[0], int.Parse(peopleData[1]));
                people.Add(person);

                // family.AddMember(person);
            }

            people = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

            // var personOne = new Person("Pesho", 20);
            // var personTwo = new Person("Gosho", 18);
            // var personThree = new Person("Stamat", 43);
        }
    }
}
