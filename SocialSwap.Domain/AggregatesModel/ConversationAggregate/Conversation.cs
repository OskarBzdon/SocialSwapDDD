using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.ConversationAggregate
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
