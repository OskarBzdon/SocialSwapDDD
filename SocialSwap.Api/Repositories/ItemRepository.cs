using SocialSwap.Domain.AggregatesModel;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Infrastructure.DataSources;

namespace SocialSwap.Api.Repositories
{
    public class ItemRepository : ICrudRepository<Item>
    {
        private readonly SocialSwapContext _ctx;

        public ItemRepository(SocialSwapContext ctx)
        {
            _ctx = ctx;
        }

        public Item Create(Item entity)
        {
            _ctx.Items.AddAsync(entity);
            _ctx.SaveChangesAsync();
            return entity;
        }

        public Item Delete(Item entity)
        {
            _ctx.Items.Remove(entity);
            _ctx.SaveChangesAsync();
            return entity;
        }

        public Item Get(int id)
        {
            return _ctx.Items.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Item> Index()
        {
            return _ctx.Items.ToList();
        }

        public Item Update(Item entity)
        {
            _ctx.Items.Update(entity);
            _ctx.SaveChangesAsync();
            return entity;
        }
    }
}
