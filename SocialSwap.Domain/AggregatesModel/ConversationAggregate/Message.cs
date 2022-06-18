using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.ConversationAggregate
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
        [Required]
        public DateTime SendDate { get; set; }
        public DateTime ReadDate { get; set; }

        public virtual User Author { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
