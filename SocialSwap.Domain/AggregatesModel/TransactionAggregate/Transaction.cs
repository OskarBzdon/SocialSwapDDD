using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.TransactionAggregate
{
    public class Transaction
    {
        public static double TransactionMargin = 10.0d;
        [Key]
        public int Id { get; set; }
        public DateTime DeliveryTime { get; set; }
        [Required]
        public string DeliveryType { get; set; }
    }
}
