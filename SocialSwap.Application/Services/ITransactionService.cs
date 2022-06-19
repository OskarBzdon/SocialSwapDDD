using SocialSwap.Domain.AggregatesModel.TransactionAggregate;

namespace SocialSwap.Application.Services
{
	public interface ITransactionService
	{
		public Task<Transaction> CreateTransaction(string offered, string wanted, string type, DateTime date);
		public Task<Transaction> ConfirmTransaction(string transactionId);
		public Task<IEnumerable<Transaction>> GetAllMyTransactions();
	}
}