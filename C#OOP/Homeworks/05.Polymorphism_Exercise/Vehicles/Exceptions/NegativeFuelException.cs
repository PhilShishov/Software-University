namespace Vehicles.Exceptions
{
    using System;

    public class NegativeFuelException : Exception
    {
        private const string EXC_MESSAGE = "Fuel must be a positive number";

        public NegativeFuelException()
            : base(EXC_MESSAGE)
        {
        }

        public NegativeFuelException(string message) : base(message)
        {
        }
    }
}
