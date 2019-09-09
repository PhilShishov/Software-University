namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using MilitaryElite.Enums;
    using MilitaryElite.Exceptions;
    using System;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            ParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            this.State = State.Finished;
        }

        private void ParseState(string stateStr)
        {
            State state;
            bool parsed = Enum.TryParse<State>(stateStr, out state);

            if (!parsed)
            {
                throw new InvalidStateException();
            }

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
