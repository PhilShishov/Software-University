namespace Chainblock.Contracts
{
    using System;

    public interface ITransaction : IComparable<ITransaction>
    {
        int Id { get; set; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        double Amount { get; set; }
    }
}