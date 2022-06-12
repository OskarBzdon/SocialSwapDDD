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

        public async Task<Item> Create(Item entity)
        {
            await _ctx.Items.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<Item> Delete(Item entity)
        {
            _ctx.Items.Remove(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<Item> Get(int id)
        {
            return _ctx.Items.FirstOrDefault(f => f.Id == id);
        }

        public async Task<IEnumerable<Item>> Index()
        {
            return _ctx.Items.ToList();
        }

        public async Task<Item> Update(Item entity)
        {
            _ctx.Items.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
    }
}
