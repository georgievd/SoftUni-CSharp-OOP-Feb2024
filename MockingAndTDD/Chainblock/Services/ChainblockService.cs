using System;
using System.Collections.Generic;
using Chainblock.Contracts;
using Chainblock.Models.Enumerations;

namespace Chainblock.Services
{
    public class ChainblockService : IChainblock
    {
        private Dictionary<int, ITransaction> _transactions;

        public ChainblockService()
        {
            _transactions = new();
        }

        public int Count => _transactions.Count;

        public void Add(ITransaction tx)
        {
            if (_transactions.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException();
            }
            _transactions.Add(tx.Id, tx);
        }

        public bool Contains(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            return _transactions.ContainsKey(id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = GetById(id);
            if (transaction != null)
            {
                transaction.Status = newStatus;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            _transactions.Remove(id);
        }

        public ITransaction GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            if (_transactions.ContainsKey(id))
            {
                return _transactions[id];
            }
            else
            {
                return default;
            }
        }
    }
}
