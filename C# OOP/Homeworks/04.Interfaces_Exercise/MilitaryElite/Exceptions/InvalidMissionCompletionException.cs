namespace MilitaryElite.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class InvalidMissionCompletionException : Exception
    {
        private const string EXC_MESSAGE = "Already completed mission!";

        public InvalidMissionCompletionException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidMissionCompletionException(string message) : base(message)
        {
        }
    }
}
