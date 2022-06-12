using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel;
using SocialSwap.Api.Repositories;

namespace SocialSwap.Api.Services
{
    public class ItemService : IItemService
    {
        private readonly ICrudRepository<Item> _repo;
        public ItemService(ICrudRepository<Item> repo)
        {
            _repo = repo;
        }

        public async Task<Item> Create(Item entity)
        {
            return await _repo.Create(entity);
        }

        public async Task<Item> Delete(Item entity)
        {
            return await _repo.Delete(entity);
        }

        public async Task<Item> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<IEnumerable<Item>> Index()
        {
            return await _repo.Index();
        }

        public async Task<Item> Update(Item entity)
        {
            return await _repo.Update(entity);
        }
    }
}
