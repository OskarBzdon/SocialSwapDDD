using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.OpinionAggregate
{
    public class Opinion
    {
        [Key]
        public int Id { get; set; }
        public bool IsAnonymous { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public bool IsOpinionPositive { get; set; }
        public virtual Client Subject { get; set; }
        public virtual Item TargetItem { get; set; }
        public virtual Client Author { get; set; }
    }
}
