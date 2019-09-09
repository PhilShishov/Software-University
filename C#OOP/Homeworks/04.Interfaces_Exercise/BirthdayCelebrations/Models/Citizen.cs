namespace BorderControl.Models
{
    using System;
    using BorderControl.Contracts;

    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id, DateTime birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public int Age { get; private set; }

        public DateTime Birthday { get; set; }
    }
}
