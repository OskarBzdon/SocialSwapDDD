using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialSwap.Domain.AggregatesModel.ReportAggregate;

namespace SocialSwap.Infrastructure.Configurations
{
    public class ReportEFConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasOne(d => d.Author).WithMany(d => d.WrotedReports).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.AssignedModerator).WithMany(d => d.Reports).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
