using System;
using Chainblock.Models;
using Chainblock.Models.Enumerations;
using NUnit.Framework;
using static Chainblock.Tests.Constants;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {


        [Test]
        public void Ctor_CreatesNewInstance()
        {
            Transaction transaction = 
                new Transaction(ValidId, ValidSender, ValidReceiver,
                    ValidAmount);
            Assert.That(transaction, Is.Not.Null);
            Assert.That(transaction.Id, Is.EqualTo(ValidId));
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.New));
            Assert.That(transaction.Sender, Is.EqualTo(ValidSender));
            Assert.That(transaction.Receiver, Is.EqualTo(ValidReceiver));
            Assert.That(transaction.Amount, Is.EqualTo(ValidAmount));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-78544)]
        public void Ctor_WithInvalidId_ThrowsException(int invalidId)
        {
            Assert.Throws<ArgumentException>(() => 
                new Transaction(invalidId, ValidSender, ValidReceiver, ValidAmount));
        }

        [TestCase("")]
        [TestCase("  ")]
        public void Ctor_WithInvalidSender_ThrowsException(string invalidFrom)
        {
            Assert.Throws<ArgumentException>(() =>
                new Transaction(ValidId, invalidFrom, ValidReceiver, ValidAmount));
        }

        [Test]
        public void Ctor_WithNullSender_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new Transaction(ValidId, null, ValidReceiver, ValidAmount));
        }


        [Test]
        public void Ctor_WithNullReceiver_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Transaction(ValidId, ValidSender, null, ValidAmount));
        }

        [TestCase("")]
        [TestCase("  ")]
        public void Ctor_WithInvalidReceiver_ThrowsException(string invalidReceiver)
        {
            Assert.Throws<ArgumentException>(() => 
                new Transaction(ValidId, ValidSender, invalidReceiver, ValidAmount));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-79855659)]
        public void Ctor_WithInvalidAmount_ThrowsException(decimal invalidAmount)
        {
            Assert.Throws<ArgumentException>(() =>
                new Transaction(ValidId, ValidSender, ValidReceiver, invalidAmount));
        }
    }
}
