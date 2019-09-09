using System;

namespace BorderControl.Contracts
{
    public interface ICitizen
    {
        string Name { get; }

        int Age { get; }

        string Id { get; }

        DateTime Birthday { get; }
    }
}
