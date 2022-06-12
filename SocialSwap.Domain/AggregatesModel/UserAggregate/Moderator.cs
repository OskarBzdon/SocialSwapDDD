using SocialSwap.Domain.AggregatesModel.ReportAggregate;
using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.UserAggregate
{
    public class Moderator : User
    {
        [Required]
        public string PESEL { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
