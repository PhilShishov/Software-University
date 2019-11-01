using System;
using System.Collections.Generic;

namespace P05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    var input = command.Split();
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string town = input[2];

                    var person = new Person(name, age, town);
                    people.Add(person);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            int positionToCompare = int.Parse(Console.ReadLine());

            int countOfMatches = 1;
            int countOfNotEqualPeople = 0;

            Person targetPerson = people[positionToCompare - 1];

            foreach (var person in people)
            {
                if (person == targetPerson)
                {
                    continue;
                }

                if (person.CompareTo(targetPerson) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotEqualPeople++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {countOfNotEqualPeople} {people.Count}");
            }
        }
    }
}
