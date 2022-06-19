using SocialSwap.Application.Dtos;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;

namespace SocialSwap.Application.Services
{
    public interface IItemService
    {
        public Task<IEnumerable<Item>> GetAll();
        public Task<IEnumerable<Item>> GetAllMy();
        public Task<Item> GetById(string id);
        public Item Create(DtoItem item);
    }
}
