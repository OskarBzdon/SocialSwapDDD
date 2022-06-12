using SocialSwap.Domain.AggregatesModel.OpinionAggregate;
using SocialSwap.Domain.AggregatesModel.ReportAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialSwap.Domain.AggregatesModel.ItemAggregate
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        [NotMapped]
        public ICollection<byte[]> Images { get; set; }

        public virtual Client Owner { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
