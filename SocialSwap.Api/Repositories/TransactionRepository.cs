using Microsoft.EntityFrameworkCore;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.TransactionAggregate;
using SocialSwap.Infrastructure.DataSources;

namespace SocialSwap.Api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SocialSwapContext _ctx;
        public TransactionRepository(SocialSwapContext ctx)
        {
            _ctx = ctx;
        }
        public Transaction ConfirmTransaction(string transactionId)
        {
            var transaction = _ctx.Transactions.Include(i => i.OfferedItem).Include(i => i.WantedItem).FirstOrDefault(f => f.Id.Equals(transactionId));
            if (transaction == null) throw new Exception("Transaction null");

            transaction.OfferedItem.SwapDate = DateTime.Now;
            transaction.WantedItem.SwapDate = DateTime.Now;

            _ctx.Items.UpdateRange(new Item[] { transaction.OfferedItem, transaction.WantedItem });
            transaction.DeliveryTime = DateTime.Now;
            _ctx.Transactions.Update(transaction);
            _ctx.SaveChanges();

            return transaction;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            _ctx.Transactions.Add(transaction);
            _ctx.SaveChanges();
            return transaction;
        }

        public IEnumerable<Transaction> GetAllMyTransactions(string clientId)
        {
            var client = _ctx.Clients.Include(i => i.Transactions).FirstOrDefault(f => f.Id.Equals(clientId));
            if (client == null) throw new Exception("Client null");
            return client.Transactions;
        }
    }
}
