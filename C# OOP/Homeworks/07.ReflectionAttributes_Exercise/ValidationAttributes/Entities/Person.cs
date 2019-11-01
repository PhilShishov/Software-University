namespace ValidationAttributes.Entities
{
    using ValidationAttributes.Attributes;

    public class Person
    {
        private const int MIN_AGE = 12;
        private const int MAX_AGE = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MIN_AGE, MAX_AGE)]
        public int Age { get; private set; }
    }
}
