using System;
using System.Collections.Generic;
using System.Reflection;
using Chainblock.Contracts;
using Chainblock.Models;
using Chainblock.Models.Enumerations;
using Chainblock.Services;
using NUnit.Framework;
using static Chainblock.Tests.Constants;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainBlock;
        private ITransaction transaction;

        [SetUp]
        public void Setup()
        {
            transaction = new Transaction(ValidId, ValidSender, ValidReceiver, ValidAmount);
            chainBlock = new ChainblockService();
        }

        [Test]
        public void Ctor_CreatesNewInstance()
        {
            ChainblockService chainblock = new ChainblockService();
            Assert.That(chainblock, Is.Not.Null);
            Assert.That(chainblock.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_CreatesNewInstance_Reflection()
        {
            ChainblockService chainblock = new ChainblockService();
            Type typeOfSut = typeof(ChainblockService);
            FieldInfo field = typeOfSut.GetField("_transactions",
                BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldValue = field.GetValue(chainblock) as Dictionary<int, ITransaction>;

            Assert.That(fieldValue, Is.Not.Null);
        }

        [Test]
        public void Contains_WhenTransaction_NotInDictionary_ReturnsFalse()
        {
            bool expectedResult = false;
            bool result = chainBlock.Contains(IdNotInCollection);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-7844)]
        public void Contains_IdIsLessThanOrEqualToZero_ThrowsException(int invalidId)
        {
            Assert.Throws<ArgumentException>(()
                => chainBlock.Contains(invalidId));
        }

        [Test]
        public void Add_HappyPath_AddsTransaction()
        {
            chainBlock.Add(transaction);
            Assert.That(chainBlock.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_TransactionAlreadyExists_ThrowsException()
        {
            chainBlock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainBlock.Add(transaction));
        }

        [Test]
        public void GetById_HappyPath()
        {
            chainBlock.Add(transaction);
            ITransaction result = chainBlock.GetById(transaction.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(transaction.Id));
            Assert.That(result.Amount, Is.EqualTo(transaction.Amount));
            Assert.That(result.Sender, Is.EqualTo(transaction.Sender));
            Assert.That(result.Receiver, Is.EqualTo(transaction.Receiver));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-104470)]
        public void GetById_IdIsInvalid_ThrowsException(int invalidId)
        {
            chainBlock.Add(transaction);
            Assert.Throws<ArgumentException>(() 
                => chainBlock.GetById(invalidId));
        }

        [Test]
        public void GetById_NonExistingId_ReturnsNull()
        {
            chainBlock.Add(transaction);
            var result = chainBlock.GetById(IdNotInCollection);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void RemoveTransactionById_HappyPath()
        {
            // 1. Setup
            chainBlock.Add(transaction);
            
            // 2. Act
            chainBlock.RemoveTransactionById(transaction.Id);
            
            // 3. Assert
            Assert.That(chainBlock.Count, Is.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-24356)]
        public void RemoveTransactionById_IdNotValid_ReturnsNull(int InvalidId)
        {
            chainBlock.Add(transaction);

            Assert.Throws<ArgumentException>(() 
                => chainBlock.RemoveTransactionById(InvalidId));
        }

        [Test]
        public void ChangeTransactionStatus_HappyPath_ChangesStatus()
        {
            chainBlock.Add(transaction);
            chainBlock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Successfull);
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void ChangeTransactionStatus_TransactionNotExisting_ThrowsException()
        {
            chainBlock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() =>
                chainBlock.ChangeTransactionStatus(IdNotInCollection, TransactionStatus.Successfull));
        }
    }
}
