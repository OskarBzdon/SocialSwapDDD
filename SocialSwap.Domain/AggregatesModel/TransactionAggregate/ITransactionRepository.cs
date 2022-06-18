using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSwap.Domain.AggregatesModel.TransactionAggregate
{
    public interface ITransactionRepository
    {
        public Transaction CreateTransaction(Transaction transaction);
        public IEnumerable<Transaction> GetAllMyTransactions(string clientId);
        public Transaction ConfirmTransaction(string transactionId);
    }
}
