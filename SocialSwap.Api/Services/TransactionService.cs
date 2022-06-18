using SocialSwap.Domain.AggregatesModel.TransactionAggregate;

namespace SocialSwap.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;
        public TransactionService(ITransactionRepository repo)
        {
            _repo = repo;
        }
        public Transaction ConfirmTransaction(string transactionId)
        {
            return _repo.ConfirmTransaction(transactionId);
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            return _repo.CreateTransaction(transaction);
        }

        public IEnumerable<Transaction> GetAllMyTransactions(string clientId)
        {
            return _repo.GetAllMyTransactions(clientId);
        }
    }
}
