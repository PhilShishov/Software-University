
namespace BillsPaymentSystem.App
{
    using BillsPaymentSystem.App.Core;
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                //context.Database.EnsureDeleted();

                //context.Database.Migrate();

                //DbInitializer.Seed(context);

                int userId = int.Parse(Console.ReadLine());

                var isUserFound = context.Users.Find(userId) != null;

                if (isUserFound)
                {
                    var user = context.Users
                      .Where(u => u.UserId == userId)
                      .Select(u => new
                      {
                          Name = $"{u.FirstName} {u.LastName}",
                          BankAccounts = u.PaymentMethods
                              .Where(pm => pm.Type == PaymentType.BankAccount)
                              .Select(pm => pm.BankAccount)
                              .ToList(),
                          CreditCards = u.PaymentMethods
                              .Where(pm => pm.Type == PaymentType.CreditCard)
                              .Select(pm => pm.CreditCard)
                              .ToList()
                      })
                      .First();

                    Console.WriteLine($"User: {user.Name}");

                    if (user.BankAccounts.Count > 0)
                    {
                        Console.WriteLine($"Bank Accounts: ");
                        foreach (var bankAccount in user.BankAccounts)
                        {
                            var bankAccountId = bankAccount.BankAccountId;
                            var bankAccountBalance = bankAccount.Balance;
                            var bankAccountName = bankAccount.BankName;
                            var bankAccountSwift = bankAccount.SWIFT;

                            Console.WriteLine($"--ID: {bankAccountId} ");
                            Console.WriteLine($"---Balance: {bankAccountBalance:F2}");
                            Console.WriteLine($"---Bank: {bankAccountName}");
                            Console.WriteLine($"---SWIFT: {bankAccountSwift}");
                        }
                    }

                    if (user.CreditCards.Count > 0)
                    {
                        Console.WriteLine($"Credit Cards: ");
                        foreach (var creditCard in user.CreditCards)
                        {
                            var creditCardId = creditCard.CreditCardId;
                            var creditCardLimit = creditCard.Limit;
                            var creditCardMoneyOwed = creditCard.MoneyOwed;
                            var creditCardLimitLeft = creditCard.LimitLeft;
                            var creditCardExpiration = creditCard.ExpirationDate;

                            Console.WriteLine($"--ID: {creditCardId} ");
                            Console.WriteLine($"---Limit: {creditCardLimit}");
                            Console.WriteLine($"---Money Owed: {creditCardMoneyOwed:F2}");
                            Console.WriteLine($"---Limit Left: {creditCardLimitLeft:F2}");
                            Console.WriteLine($"---Expiration Date: {creditCardExpiration.ToString("yyyy/MM")}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"User with id {userId} not found!");
                }

                PayBills();

            }
        }

        static void PayBills()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                try
                {
                    Console.WriteLine("Bills Payment");
                    Console.Write("Enter user ID: ");
                    int userId = int.Parse(Console.ReadLine());
                    Console.Write("Enter amount: ");
                    decimal amount = decimal.Parse(Console.ReadLine());

                    var accounts = context.PaymentMethods
                        .Include(pm => pm.BankAccount)
                        .Where(pm => pm.UserId == userId && pm.Type == PaymentType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToList();

                    var cards = context.PaymentMethods
                        .Include(pm => pm.CreditCard)
                        .Where(pm => pm.UserId == userId && pm.Type == PaymentType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToList();

                    var moneyAvailable = accounts.Select(ba => ba.Balance).Sum() + cards.Select(cc => cc.LimitLeft).Sum();

                    if (moneyAvailable < amount)
                    {
                        throw new Exception("Insufficient Funds");

                        return;
                    }

                    foreach (var account in accounts)
                    {
                        if (amount == 0 || account.Balance == 0)
                        {
                            continue;
                        }

                        decimal moneyInAccount = account.Balance;
                        if (moneyInAccount < amount)
                        {
                            account.Withdraw(moneyInAccount);
                            amount -= moneyInAccount;
                        }
                        else
                        {
                            account.Withdraw(amount);
                            amount -= amount;
                        }
                    }


                    foreach (var creditCard in cards)
                    {
                        if (amount == 0 || creditCard.LimitLeft == 0)
                        {
                            continue;
                        }

                        decimal limitLeft = creditCard.LimitLeft;
                        if (limitLeft < amount)
                        {
                            creditCard.Withdraw(limitLeft);
                            amount -= limitLeft;
                        }
                        else
                        {
                            creditCard.Withdraw(amount);
                            amount -= amount;
                        }
                    }

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
