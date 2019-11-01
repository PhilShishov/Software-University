
namespace ValidationAttributes
{
    using System;
    using ValidationAttributes.Entities;
    using ValidationAttributes.Utilities;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null,
                 -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
