namespace Vehicles.Exceptions
{
    using System;

    public class InvalidFuelAmountException : Exception
    {
        private const string EXC_MESSAGE = "Cannot fit {0} fuel in the tank";

        public InvalidFuelAmountException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidFuelAmountException(string message) : base(message)
        {
        }
    }
}
