using SocialSwap.Domain.AggregatesModel.TransactionAggregate;
using System.Text;
using System.Text.Json;

namespace SocialSwap.Application.Services
{
	public class TransactionService : ITransactionService
	{
		private readonly HttpClient _httpClient;

		public TransactionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<Transaction> ConfirmTransaction(string transactionId)
		{
			var model = JsonSerializer.Serialize(new { transactionId = transactionId });
			var response = await _httpClient.PutAsync("https://localhost:7000/api/transaction/confirmoffer?transactionId=" + transactionId, new StringContent(model, Encoding.UTF8, "application/json"));
			var content = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<Transaction>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			return result;
		}

		public async Task<Transaction> CreateTransaction(string offered, string wanted, string type, DateTime date)
		{
			var model = JsonSerializer.Serialize(new { wantedItemId = wanted, offeredItemId = offered, deliveryTime = date, deliveryType = type});
			var response = await _httpClient.PostAsync("https://localhost:7000/api/transaction/swapitem", new StringContent(model, Encoding.UTF8, "application/json"));
			var content = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<Transaction>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			return result;
		}

		public async Task<IEnumerable<Transaction>> GetAllMyTransactions()
		{
			var response = await _httpClient.GetAsync("https://localhost:7000/api/transaction/seemyoffers");
			var content = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<IEnumerable<Transaction>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			return result;
		}
	}
}
