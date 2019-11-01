namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Puppy puppy = new Puppy();

            //puppy.Eat();
            //puppy.Bark();
            //puppy.Weep();

            Dog dog = new Dog();

            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();

            cat.Eat();
            cat.Meow();

        }
    }
}
