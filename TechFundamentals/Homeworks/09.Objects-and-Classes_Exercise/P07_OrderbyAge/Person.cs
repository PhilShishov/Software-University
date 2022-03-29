
namespace P07_OrderbyAge
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
}
