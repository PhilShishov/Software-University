
namespace P04_Elevator
{
    using System;

    class Elevator
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = numberPeople / capacity;
            int remainingCourses = numberPeople % capacity;

            if (remainingCourses <= capacity && numberPeople % capacity != 0)
            {
                courses += 1;
            }

            Console.WriteLine($"{courses}");
        }
    }
}
