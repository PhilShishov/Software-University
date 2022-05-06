
namespace Chainblock.Tests
{
    using System;
    using System.Diagnostics;

    using NUnit.Framework;

    using Chainblock.Contracts;
    using Chainblock.Enum;
    using Chainblock.Models;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ChainblockTestsPerformance
    {
        private const int COUNT = 10000;
        private IDistributedLedger cb;
        private Stopwatch sw;
        private Random rand;
        private TransactionStatus[] statuses;
        private List<ITransaction> txs;

        [SetUp]
        public void Setup()
        {
            this.cb = new DistributedLedger();
            this.sw = new Stopwatch();
            this.rand = new Random();
            this.statuses = new TransactionStatus[]
            {
                TransactionStatus.Aborted,
                TransactionStatus.Failed,
                TransactionStatus.Successfull,
                TransactionStatus.Unauthorized
            };
            this.txs = new List<ITransaction>();
        }
        [Test]
        public void Add_100000_Transactions_Should_WorkFast()
        {
            sw.Start();
            for (int i = 0; i < COUNT; i++)
            {
                //int status = rand.Next(0, 4);
                cb.Add(new Transaction(i, TransactionStatus.Successfull,
                    i.ToString(), i.ToString(), i));
            }

            sw.Stop();
            Assert.AreEqual(COUNT, cb.Count);
            Assert.IsTrue(sw.ElapsedMilliseconds < 400);
        }

        [Test]
        public void Contains_100000_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int status = rand.Next(0, 4);
                Transaction tx = new Transaction(i, statuses[status],
                    i.ToString(), i.ToString(), i);
                cb.Add(tx);
                txs.Add(tx);
            }

            Assert.AreEqual(COUNT, cb.Count);

            sw.Start();

            foreach (Transaction tx in txs)
            {
                Assert.IsTrue(cb.Contains(tx));
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.Less(l1, 200);
        }

        [Test]
        public void ContainsById_100000_ShouldWorkFast()
        {
            sw.Start();
            for (int i = 0; i < COUNT; i++)
            {
                int status = rand.Next(0, 4);
                Transaction tx = new Transaction(i, statuses[status],
                    i.ToString(), i.ToString(), i);
                cb.Add(tx);
                txs.Add(tx);
            }

            sw.Stop();
            Assert.AreEqual(COUNT, cb.Count);

            sw.Start();

            foreach (Transaction tx in txs)
            {
                Assert.IsTrue(cb.Contains(tx.Id));
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.Less(l1, 200);
        }

        [Test]
        public void ChangeTransactionStatus_ShouldWorkFast()
        {
            for (int i = 0; i < 90000; i++)
            {
                int amount = rand.Next(0, 50000);
                int status = amount % 4;
                Transaction tx = new Transaction(i, statuses[status],
                    i.ToString(), i.ToString(), amount);
                cb.Add(tx);
                txs.Add(tx);
            }

            int count = cb.Count;
            Assert.AreEqual(90000, count);

            sw.Start();

            foreach (Transaction tx in txs)
            {
                int status = rand.Next(0, 4);
                cb.ChangeTransactionStatus(tx.Id, statuses[status]);
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;
            Assert.Less(l1, 330);
        }

        [Test]
        public void RemoveById_ShoudlWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int amount = rand.Next(0, 40000);
                int status = amount % 4;
                Transaction tx = new Transaction(i, (TransactionStatus)status,
                    i.ToString(), i.ToString(), amount);
                cb.Add(tx);
                txs.Add(tx);
            }

            int count = cb.Count;
            Assert.AreEqual(COUNT, count);

            sw.Start();

            foreach (Transaction tx in txs)
            {
                cb.RemoveTransactionById(tx.Id);
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;
            Assert.Less(l1, 220);
        }

        [Test]
        public void GetById_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int status = rand.Next(0, 4);
                Transaction tx = new Transaction(i, statuses[status],
                    i.ToString(), i.ToString(), i);
                cb.Add(tx);
                txs.Add(tx);
            }

            int count = cb.Count;
            Assert.AreEqual(COUNT, count);

            sw.Start();

            foreach (Transaction tx in txs)
            {
                Assert.AreSame(tx, cb.GetById(tx.Id));
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 150);
        }

        [Test]
        public void GetByTransactionStatus_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int amount = rand.Next(0, 50000);
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    i.ToString(), i.ToString(), amount);

                cb.Add(tx);
                txs.Add(tx);
            }

            int count = cb.Count;
            Assert.AreEqual(COUNT, count);
            sw.Start();

            var byStatus = cb.GetByTransactionStatus(TransactionStatus.Successfull);
            int c = 0;

            foreach (Transaction employee in byStatus)
            {
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 150);
            Assert.AreEqual(COUNT, c);
        }

        [Test]
        public void GetOrderedByAmountDescendingThenById_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    i.ToString(), i.ToString(), i);
                cb.Add(tx);
                txs.Add(tx);
            }

            int count = cb.Count;
            Assert.AreEqual(COUNT, count);

            sw.Start();

            var all = cb.GetAllOrderedByAmountDescendingThenById();
            int c = 0;
            foreach (Transaction tx in all)
            {
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 150);
            Assert.AreEqual(COUNT, c);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    "sender", i.ToString(), i);
                cb.Add(tx);
                txs.Add(tx);
            }

            int count = cb.Count;
            txs = txs.OrderByDescending(x => x.Amount).ToList();
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<ITransaction> all = cb.GetBySenderOrderedByAmountDescending("sender");
            int c = 0;
            foreach (Transaction tx in all)
            {
                Assert.AreSame(tx, txs[c]);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 200);
            Assert.AreEqual(COUNT, c);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    i.ToString(), "to", i);
                cb.Add(tx);
                txs.Add(tx);
            }

            int count = cb.Count;
            txs = txs.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<ITransaction> all = cb.GetByReceiverOrderedByAmountThenById("to");
            int c = 0;
            foreach (Transaction tx in all)
            {
                Assert.AreSame(tx, txs[c]);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 200);
            Assert.AreEqual(COUNT, c);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int amount = rand.Next(0, 1000);
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    i.ToString(), i.ToString(), amount);
                cb.Add(tx);
                if (amount <= 500)
                {
                    txs.Add(tx);
                }
            }
            txs = txs.OrderByDescending(x => x.Amount).ToList();
            int count = cb.Count;
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<ITransaction> all = cb.GetByTransactionStatusAndMaximumAmount(
                TransactionStatus.Successfull, 500);
            int c = 0;
            foreach (Transaction tx in all)
            {
                Assert.AreSame(tx, txs[c]);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 150);
            Assert.AreEqual(txs.Count, c);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int amount = rand.Next(0, 1000);
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    "sender", i.ToString(), amount);
                cb.Add(tx);
                if (amount > 500)
                {
                    txs.Add(tx);
                } 
            }
            txs = txs.OrderByDescending(x => x.Amount).ToList();
            int count = cb.Count;
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<ITransaction> all = cb.GetBySenderAndMinimumAmountDescending(
                "sender", 500);
            int c = 0;
            foreach (Transaction tx in all)
            {
                Assert.AreSame(tx, txs[c]);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 150);
            Assert.AreEqual(txs.Count, c);
        }

        [Test]
        public void GetByReceiverAndAmountRange()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int amount = rand.Next(0, 1000);
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    "sender", "from", amount);
                cb.Add(tx);
                if (amount >= 200 && amount < 600)
                {
                    txs.Add(tx);
                }
            }
            txs = txs.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            int count = cb.Count;
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<ITransaction> all = cb.GetByReceiverAndAmountRange(
                "from", 200, 600);
            int c = 0;
            foreach (Transaction tx in all)
            {
                Assert.AreSame(tx, txs[c]);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 150);
            Assert.AreEqual(txs.Count, c);
        }

        [Test]
        public void GetAllInAmountRange()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int amount = rand.Next(0, 1000);
                Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    "sender", "from", amount);
                cb.Add(tx);
                if (amount >= 200 && amount <= 600)
                {
                    txs.Add(tx);
                }
            }
            int count = cb.Count;
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<ITransaction> all = cb.GetAllInAmountRange(200, 600);
            int c = 0;
            foreach (Transaction tx in all)
            {
                Assert.AreSame(tx, txs[c]);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.IsTrue(l1 < 150);
            Assert.AreEqual(txs.Count, c);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int status = rand.Next(0, 4);
                TransactionStatus TS = statuses[status];
                Transaction tx = new Transaction(i, TS,
                    i.ToString(), i.ToString(), i);
                cb.Add(tx);
                if (TS == TransactionStatus.Successfull)
                {
                    txs.Add(tx);
                }
            }

            int count = cb.Count;
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<string> all = cb.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            int c = 0;
            foreach (string tx in all)
            {
                Assert.AreEqual(tx, txs[c].From);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.Less(l1, 150);
            Assert.AreEqual(txs.Count, c);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldWorkFast()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int status = rand.Next(0, 4);
                TransactionStatus TS = statuses[status];
                Transaction tx = new Transaction(i, TS,
                    i.ToString(), i.ToString(), i);
                cb.Add(tx);
                if (status == 2)
                {
                    txs.Add(tx);
                }
            }
            int count = cb.Count;
            Assert.AreEqual(COUNT, count);
            sw.Start();

            IEnumerable<string> all = cb.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            int c = 0;
            foreach (string tx in all)
            {
                Assert.AreEqual(tx, txs[c].To);
                c++;
            }

            sw.Stop();
            long l1 = sw.ElapsedMilliseconds;

            Assert.Less(l1, 150);
            Assert.AreEqual(txs.Count, c);
        }
    }
}
