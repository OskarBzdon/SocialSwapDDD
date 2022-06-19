using Blazored.LocalStorage;
using SocialSwap.Application.Dtos;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace SocialSwap.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Item Create(DtoItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            var response = await _httpClient.GetAsync("https://localhost:7000/item/getall");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Item>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

		public async Task<IEnumerable<Item>> GetAllMy()
		{
            var response = await _httpClient.GetAsync("https://localhost:7000/item/myitems");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Item>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

		public async Task<Item> GetById(string id)
        {
            var response = await _httpClient.GetAsync("https://localhost:7000/Item/details?id="+id);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Item>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }
    }
}
