using System;

namespace FoodShortage.Contracts
{
    public interface ICitizen
    {
        string Id { get; }

        DateTime Birthday { get; }
    }
}
