
namespace Chainblock.Models
{
    using Chainblock.Contracts;
    using Chainblock.Enum;

    public class Transaction : ITransaction
    {
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
    }
}
