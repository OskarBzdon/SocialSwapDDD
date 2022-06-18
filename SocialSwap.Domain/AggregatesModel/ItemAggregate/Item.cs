using SocialSwap.Domain.AggregatesModel.OpinionAggregate;
using SocialSwap.Domain.AggregatesModel.ReportAggregate;
using SocialSwap.Domain.AggregatesModel.TransactionAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialSwap.Domain.AggregatesModel.ItemAggregate
{
    public class Item // TODO: Splaszczyc strukture z Diplay i Swap poniewaz Discriminator okreslajacy typ obiektu nie powinien byc zmieniany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [NotMapped]
        public ICollection<byte[]> Images { get; set; }
        /// <summary>
        /// If set, Itemm become swapped item on cindition DisplayDate has been assgined
        /// </summary>
        public DateTime? SwapDate { get; set; } = null;
        /// <summary>
        /// If set, Item become displayed item
        /// </summary>
        public DateTime? DisplayDate { get; set; } = DateTime.Now;

        public virtual Client Owner { get; set; }
        public virtual ICollection<Transaction> Offers { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
