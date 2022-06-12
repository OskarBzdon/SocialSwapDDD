using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.ItemAggregate
{
    public class SwapItem : Item
    {
        [Required]
        public DateTime SwapDate { get; set; }
    }
}
