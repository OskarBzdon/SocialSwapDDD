using Microsoft.EntityFrameworkCore;
using SocialSwap.Domain.AggregatesModel.ConversationAggregate;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.OpinionAggregate;
using SocialSwap.Domain.AggregatesModel.ReportAggregate;
using SocialSwap.Domain.AggregatesModel.TransactionAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using SocialSwap.Infrastructure.Configurations;

namespace SocialSwap.Infrastructure.DataSources
{
    public class SocialSwapContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CompleteReport> CompleteReports { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<DisplayedItem> DisplayedItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SwapItem> SwapItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public SocialSwapContext() : base()
        {

        }
        public SocialSwapContext(DbContextOptions<SocialSwapContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AddressEFConfiguration());
            modelBuilder.ApplyConfiguration(new ReportEFConfiguration());
            modelBuilder.ApplyConfiguration(new OpinionEFConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEFConfiguration());

        }
    }
}
