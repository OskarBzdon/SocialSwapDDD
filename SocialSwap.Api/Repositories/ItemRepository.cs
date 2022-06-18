using Microsoft.EntityFrameworkCore;
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
            _ctx.Items.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public Item Delete(Item entity)
        {
            _ctx.Items.Remove(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public Item Get(string id)
        {
            return _ctx.Items.Include(i =>i.Owner).FirstOrDefault(f => f.Id.Equals(id));
        }

        public IEnumerable<Item> Index(string? selfId = null)
        {
            return _ctx.Items.Where(w => w.SwapDate == null).Where(w => !w.Owner.Id.Equals(selfId)).Include(i => i.Owner).ToList();
        }

        public Item Update(Item entity)
        {
            _ctx.Items.Update(entity);
            _ctx.SaveChanges();
            return entity;
        }
    }
}
