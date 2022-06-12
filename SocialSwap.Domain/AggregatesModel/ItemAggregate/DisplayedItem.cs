using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.ItemAggregate
{
    public class DisplayedItem : Item
    {
        [Required]
        public DateTime DisplayDate { get; set; }
    }
}
