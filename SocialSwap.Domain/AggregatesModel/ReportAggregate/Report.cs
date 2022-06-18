using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.ReportAggregate
{
    public class Report
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual Client Author { get; set; }
        public virtual Moderator AssignedModerator { get; set; }
    }
}
