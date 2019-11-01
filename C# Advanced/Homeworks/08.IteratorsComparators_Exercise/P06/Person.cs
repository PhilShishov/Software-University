namespace P06
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                return this.Age.CompareTo(other.Age);
            }           

            return result;
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Person)obj).Name && this.Age == ((Person)obj).Age;
        }

        public override int GetHashCode()
        {
            //Prime numbers 257 and 53
            return this.Name.GetHashCode() + this.Age.GetHashCode() + (257 * 53);
        }
    }
}
