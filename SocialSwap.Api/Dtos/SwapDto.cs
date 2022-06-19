namespace SocialSwap.Api.Dtos
{
	public class SwapDto
	{
		public string wantedItemId { get; set; }
		public string offeredItemId { get; set; }
		public DateTime deliveryTime { get; set; }
		public string deliveryType { get; set; }
	}
}
