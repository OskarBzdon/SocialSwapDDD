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

        public Item Create(Item entity)
        {
            return _repo.Create(entity);
        }

        public Item Delete(Item entity)
        {
            return _repo.Delete(entity);
        }

        public Item Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<Item> Index()
        {
            return _repo.Index();
        }

        public Item Update(Item entity)
        {
            return _repo.Update(entity);
        }
    }
}
