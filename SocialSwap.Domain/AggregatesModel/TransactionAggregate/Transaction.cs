using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialSwap.Domain.AggregatesModel.TransactionAggregate
{
    public class Transaction
    {
        public static double TransactionMargin = 10.0d;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime DeliveryTime { get; set; }
        [Required]
        public string DeliveryType { get; set; }
        public virtual Client Receiver { get; set; }
        public virtual Item WantedItem { get; set; }
        public virtual Item OfferedItem { get; set; }
    }
}
