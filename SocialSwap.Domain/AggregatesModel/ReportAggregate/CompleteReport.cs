using SocialSwap.Domain.AggregatesModel.TransactionAggregate;
using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.ReportAggregate
{
    public class CompleteReport : Report
    {
        [Required]
        public DateTime CloseDate { get; set; }
        public string Explanation { get; set; }
        [Required]
        public bool IsReportAccepted { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
