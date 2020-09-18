
namespace BillsPaymentSystem.Models
{
    using BillsPaymentSystem.Models.Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreditCard
    {
        public int CreditCardId { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Limit { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft =>
            this.Limit - this.MoneyOwed;

        [ExpirationDateAttribute]
        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.MoneyOwed -= amount;
        }

        public void Withdraw(decimal amount)
        {
            if (this.LimitLeft < amount || amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.MoneyOwed += amount;
        }
    }
}
