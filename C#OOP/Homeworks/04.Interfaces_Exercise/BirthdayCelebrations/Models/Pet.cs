namespace BirthdayCelebrations.Models
{
    using BirthdayCelebrations.Contracts;
    using System;

    public class Pet : IPet
    {
        public Pet(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }

        public DateTime Birthday { get; private set; }
    }
}
