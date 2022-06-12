using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.OpinionAggregate;
using SocialSwap.Domain.AggregatesModel.ReportAggregate;

namespace SocialSwap.Domain.AggregatesModel.UserAggregate
{
    public class Client : User
    {
        public virtual Address Address { get; set; }
        public int Reputation { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Opinion> WrotedOpinions { get; set; }
        public virtual ICollection<Report> WrotedReports { get; set; }
    }
}
