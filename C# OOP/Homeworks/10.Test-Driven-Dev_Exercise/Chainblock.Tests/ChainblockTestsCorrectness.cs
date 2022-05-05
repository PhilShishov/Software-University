namespace Chainblock.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using Chainblock.Contracts;
    using Chainblock.Enum;
    using Chainblock.Models;

    [TestFixture]
    public class ChainblockTestsCorrectness
    {
        private IDistributedLedger cb;
        private ITransaction tx1;
        private ITransaction tx2;
        private ITransaction tx3;
        private ITransaction tx4;
        private ITransaction tx5;

        [SetUp]
        public void Setup()
        {
            this.cb = new DistributedLedger();
            this.tx1 = new Transaction(5, TransactionStatus.Successfull, "George", "Peter", 1);
            this.tx2 = new Transaction(6, TransactionStatus.Aborted, "George", "Peter", 5.5);
            this.tx3 = new Transaction(7, TransactionStatus.Successfull, "George", "Peter", 5.5);
            this.tx4 = new Transaction(12, TransactionStatus.Unauthorized, "George", "Peter", 15.6);
            this.tx5 = new Transaction(15, TransactionStatus.Unauthorized, "Michael", "Viktor", 7.8);
        }

        //Addition
        [Test]
        public void Add_SingleElement_ShouldWorkCorrectly()
        {
            cb.Add(tx1);

            foreach (var transaction in cb)
            {
                Assert.AreSame(transaction, transaction);
            }
        }

        [Test]
        public void Add_SingleElement_ShouldIncreaseCountTo1()
        {
            cb.Add(tx1);

            foreach (var transaction in cb)
            {
                Assert.AreSame(transaction, transaction);
            }

            Assert.AreEqual(1, cb.Count);
        }

        [Test]
        public void Add_MultipleElements_CB_ShouldContainThem()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);

            Assert.IsTrue(cb.Contains(tx2));
            Assert.IsTrue(cb.Contains(tx2));
            Assert.IsTrue(cb.Contains(tx3));
        }

        [Test]
        public void Add_MultipleElements_CB_ShouldContainThemById()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);

            Assert.IsTrue(cb.Contains(tx1.Id));
            Assert.IsTrue(cb.Contains(tx2.Id));
            Assert.IsTrue(cb.Contains(tx3.Id));
        }

        [Test]
        public void Contains_OnEmptyChainblock_ShouldReturnFalse()
        {
            Assert.IsFalse(cb.Contains(5));
            Assert.IsFalse(cb.Contains(new Transaction(3, TransactionStatus.Failed, "a", "b", 0.5)));
        }

        [Test]
        public void Contains_OnExistingElement_ShouldReturnTrue()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);

            Assert.IsTrue(cb.Contains(5));
            Assert.IsFalse(cb.Contains(3));
            Assert.IsTrue(cb.Contains(tx2));
            Assert.IsFalse(cb.Contains(new Transaction(0, TransactionStatus.Failed, "b", "b", 5)));
        }

        [Test]
        public void Count_Should_IncreaseOnMultiple_Elements()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);

            Assert.AreEqual(3, cb.Count);
        }

        [Test]
        public void Count_Should_Be_0_On_EmptyCollection()
        {
            IDistributedLedger cbNew = new DistributedLedger();

            Assert.AreEqual(0, cbNew.Count);
        }

        [Test]
        public void Count_Should_RemainCorrect_AfterRemoving()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);
            cb.RemoveTransactionById(tx1.Id);
            cb.RemoveTransactionById(tx3.Id);

            Assert.AreEqual(1, cb.Count);
            Assert.AreNotSame(tx1, cb.GetById(tx2.Id));
        }

        [Test]
        public void GetById_On_ExistingElement_ShouldWorkCorrectly()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);

            Assert.AreSame(tx1, cb.GetById(5));
            Assert.AreNotSame(
                new Transaction(53, TransactionStatus.Failed, "a", "b", 5),
                cb.GetById(7)
            );
        }

        [Test]
        public void GetById_On_NonExistingElement_ShouldThrow()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);
            cb.RemoveTransactionById(5);

            Assert.Throws<InvalidOperationException>(() => cb.GetById(5));
        }

        [Test]
        public void GetById_On_Empty_Chainblock_ShouldThrow()
        {
            IDistributedLedger cbNew = new DistributedLedger();

            Assert.Throws<InvalidOperationException>(() => cbNew.GetById(5));
        }

        [Test]
        public void ChangeTransactionStatus_ShouldWorkCorrectly_On_ExistingTX()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);
            cb.ChangeTransactionStatus(5, TransactionStatus.Aborted);

            Assert.AreEqual(TransactionStatus.Aborted, tx1.Status);
            Assert.AreEqual(3, cb.Count);
        }

        [Test]
        public void ChangeTransactionStatus_OnMultipleTransactions_ShouldWorkCorrectly()
        {
            cb.Add(tx1);
            cb.Add(tx2);
            cb.Add(tx3);
            cb.ChangeTransactionStatus(7, TransactionStatus.Unauthorized);
            cb.ChangeTransactionStatus(5, TransactionStatus.Aborted);
            cb.ChangeTransactionStatus(6, TransactionStatus.Successfull);

            Assert.AreEqual(3, cb.Count);
            Assert.AreEqual(tx1.Status, TransactionStatus.Aborted);
            Assert.AreEqual(tx3.Status, TransactionStatus.Unauthorized);
            Assert.AreEqual(tx2.Status, TransactionStatus.Successfull);
        }

        [Test]
        public void ChangeTransactionStatus_On_NonExistingTranasction_ShouldThrow()
        {
            IDistributedLedger cbNew = new DistributedLedger();

            Assert.Throws<ArgumentException>(
                () => cb.ChangeTransactionStatus(6, TransactionStatus.Failed)
            );
        }

        [Test]
        public void GetInAmountRange_ShouldReturn_CorrectTransactionsByInsertionOrder()
        {
            var expected = new List<ITransaction>()
            {
                tx4,tx5
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            var actual = cb.GetAllInAmountRange(7.8, 16).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturn_EmptyCollectionOnNonExistingRange()
        {
            var expected = new List<Transaction>();

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            var actual = cb.GetAllInAmountRange(7.7, 7.75).ToList();

            CollectionAssert.AreEqual(expected, actual);
            cb.RemoveTransactionById(12);
            cb.RemoveTransactionById(15);
            actual = cb.GetAllInAmountRange(7.8, 16).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnEmptyEnumeration_On_EmptyCB()
        {
            var actual = cb.GetAllInAmountRange(7.7, 7.75).ToList();

            CollectionAssert.AreEqual(new List<Transaction>(), actual);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldWorkCorrectly()
        {
            var expected = new List<ITransaction>()
            {
                tx4,tx5,tx2,tx3,tx1
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            var actual = cb.GetAllOrderedByAmountDescendingThenById().ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldWorkCorrectlyAfterRemove()
        {
            var expected = new List<ITransaction>()
            {
                tx5,tx3,tx1
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            var before = cb.GetAllOrderedByAmountDescendingThenById().ToList();
            Assert.AreEqual(5, before.Count);
            cb.RemoveTransactionById(tx4.Id);
            cb.RemoveTransactionById(tx2.Id);
            var actual = cb.GetAllOrderedByAmountDescendingThenById().ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnEmpty_OnEmptyCB()
        {
            var actual = cb.GetAllOrderedByAmountDescendingThenById().ToList();

            CollectionAssert.AreEqual(new List<Transaction>(), actual);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldWorkCorrectly()
        {
            var expected = new List<string>()
            {
                "Michael", "George"
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            var actual = cb
                .GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized)
                .ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_OnNonExistantTxs_ShouldThrow()
        {
            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            Assert.Throws<InvalidOperationException>(
                () => cb.GetAllSendersWithTransactionStatus(TransactionStatus.Failed)
            );
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShoudlThrowAfterRemove()
        {
            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            cb.RemoveTransactionById(5);
            cb.RemoveTransactionById(7);
            cb.RemoveTransactionById(6);
            cb.RemoveTransactionById(12);
            cb.RemoveTransactionById(15);

            Assert.Throws<InvalidOperationException>(() =>
            {
                cb.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);
            });
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldWorkCorrectly()
        {
            var expected = new List<string>()
            {
                "Viktor", "Peter"
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            var actual = cb
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized)
                .ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_OnNonExistantTxs_ShouldThrow()
        {
            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            Assert.Throws<InvalidOperationException>(
                () => cb.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed)
            );
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShoudlThrowAfterRemove()
        {
            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);
            cb.RemoveTransactionById(5);
            cb.RemoveTransactionById(7);
            cb.RemoveTransactionById(6);
            cb.RemoveTransactionById(12);
            cb.RemoveTransactionById(15);

            Assert.Throws<InvalidOperationException>(() =>
            {
                cb.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
            });
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldWorkCorrectly_On_CorrectRange()
        {
            var expected = new List<ITransaction>()
            {
                tx4, tx2, tx3, tx1
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb.GetByReceiverAndAmountRange("Peter", 0, 20).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrow_AfterRemovingReceiver()
        {
            cb.Add(tx1);
            cb.Add(tx5);
            cb.RemoveTransactionById(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                cb.GetByReceiverAndAmountRange("Peter", 0, 20).ToList();
            });
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrow_On_EmptyCB()
        {
            IDistributedLedger cbNew = new DistributedLedger();

            Assert.Throws<InvalidOperationException>(() =>
            {
                cbNew.GetByReceiverAndAmountRange("Peter", 0, 20).ToList();
            });
        }

        [Test]
        public void GetByReceiver_ShouldWorkCorrectly()
        {
            var expected = new List<ITransaction>()
            {
                tx4, tx2, tx3, tx1
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb.GetByReceiverOrderedByAmountThenById("Peter").ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiver_On_NonExisting_Receiver_ShouldThrow()
        {
            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                cb.GetByReceiverOrderedByAmountThenById("non existing");
            });
        }

        [Test]
        public void GetByReceiver_ShouldThrow_On_EmptyCB()
        {
            IDistributedLedger cbNew = new DistributedLedger();

            Assert.Throws<InvalidOperationException>(() =>
            {
                cbNew.GetByReceiverOrderedByAmountThenById("Peter");
            });
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldWorkCorrectly_OnExistingSender()
        {
            var expected = new List<ITransaction>()
            {
                tx4
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb.GetBySenderAndMinimumAmountDescending("George", 7.5).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrow_OnMissingSender()
        {
            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                cb.GetBySenderAndMinimumAmountDescending("missing sender", 15.5).ToList();
            });
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldOrderAndPickCorrectly()
        {
            var expected = new List<ITransaction>()
            {
               tx5
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb.GetBySenderAndMinimumAmountDescending("Michael", 7.5).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowOnEmpty_CB()
        {
            IDistributedLedger cbNew = new DistributedLedger();

            Assert.Throws<InvalidOperationException>(() =>
            {
                cbNew.GetBySenderAndMinimumAmountDescending("Peter", 5);
            });
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldWorkCorrectly_OnExistingSender()
        {
            var expected = new List<ITransaction>()
            {
               tx4, tx3, tx2, tx1
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb.GetBySenderOrderedByAmountDescending("George").ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTransactionStatus_ShouldReturnCorrectResult()
        {
            var expected = new List<ITransaction>()
            {
               tx3, tx1
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb
                .GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldWorkCorrectly()
        {
            var expected = new List<ITransaction>()
            {
                tx3, tx1
            };

            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb
                 .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 15.0)
                 .ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection()
        {
            cb.Add(tx1);
            cb.Add(tx3);
            cb.Add(tx2);
            cb.Add(tx4);
            cb.Add(tx5);

            var actual = cb
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 5)
                .ToList();

            CollectionAssert.AreEqual(new List<Transaction>(), actual);

            IDistributedLedger cbNew = new DistributedLedger();
            actual = cbNew
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 10)
                .ToList();

            CollectionAssert.AreEqual(new List<Transaction>(), actual);
        }
    }
}
