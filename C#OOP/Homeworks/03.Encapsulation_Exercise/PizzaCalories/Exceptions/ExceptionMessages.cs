namespace PizzaCalories.Exceptions
{
    public static class ExceptionMessages
    {
        public static string InvalidPizzaNameLength = "Pizza name should be between 1 and 15 symbols.";
        public static string InvalidToppingsCount = "Number of toppings should be in range [0..10].";
        public static string InvalidToppingType = "Cannot place {0} on top of your pizza.";
        public static string InvalidToppingWeight = "{0} weight should be in the range [1..50].";
        public static string InvalidTypeOfDough = "Invalid type of dough.";
        public static string InvalidDoughWeight = "Dough weight should be in the range [1..200].";
    }
}
