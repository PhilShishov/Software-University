namespace BirthdayCelebrations.Contracts
{
    using System;

    public interface IPet
    {
        string Name { get; }

        DateTime Birthday { get; }
    }
}