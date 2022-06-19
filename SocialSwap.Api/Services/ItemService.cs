using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel;
using SocialSwap.Api.Repositories;

namespace SocialSwap.Api.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _repo;
        public ItemService(ICrudRepository<Item> repo)
        {
            _repo = (ItemRepository?)repo;
        }

        public Item Create(Item entity)
        {
            return _repo.Create(entity);
        }

        public Item Delete(Item entity)
        {
            return  _repo.Delete(entity);
        }

        public Item Get(string id)
        {
            return  _repo.Get(id);
        }

        public IEnumerable<Item> Index(string? selfId = null)
        {
            return  _repo.Index(selfId);
        }

		public IEnumerable<Item> MyList(string clientId)
		{
            return _repo.Index().Where(w => w.Owner.Id.Equals(clientId));
        }

		public Item Update(Item entity)
        {
            return  _repo.Update(entity);
        }
    }
}
