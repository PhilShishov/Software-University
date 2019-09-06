namespace Animals
{
    using Animals.Cats;
    using Animals.Core;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }
        public void Run()
        {
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                try
                {
                    string[] animalArgs = Console.ReadLine().Split();

                    string name = animalArgs[0];
                    int age = int.Parse(animalArgs[1]);
                    string gender = animalArgs[2];

                    switch (animalType)
                    {
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                catch (InvalidInputException exception)
                {
                    Console.WriteLine(exception.Message);
                }                

                animalType = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
