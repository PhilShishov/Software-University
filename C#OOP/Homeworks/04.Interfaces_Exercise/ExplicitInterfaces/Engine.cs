namespace ExplicitInterfaces
{
    using System;

    public class Engine
    {
        private readonly PersonFactory personFactory;

        public Engine()
        {
            this.personFactory = new PersonFactory();
        }
        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var citizenInfo = input.Split();

                IPerson person = this.personFactory.MakeCitizen(citizenInfo);
                IResident resident = this.personFactory.MakeCitizen(citizenInfo);

                Console.WriteLine(resident.GetName());
                Console.WriteLine(person.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
