namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using System;

    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString().TrimEnd() + Environment.NewLine + $"Code Number: {this.CodeNumber}";
        }
    }
}
