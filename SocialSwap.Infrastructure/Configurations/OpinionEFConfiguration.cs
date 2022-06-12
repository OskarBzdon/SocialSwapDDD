using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialSwap.Domain.AggregatesModel.OpinionAggregate;

namespace SocialSwap.Infrastructure.Configurations
{
    public class OpinionEFConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.HasOne(d => d.Subject).WithMany(d => d.Opinions).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.Author).WithMany(d => d.WrotedOpinions).OnDelete(DeleteBehavior.ClientSetNull);

            var opinions = new List<Opinion>();

            //opinions.Add(new Opinion()
            //{

            //});
            //opinions.Add(new Opinion()
            //{

            //});

            //builder.HasData(opinions);
        }
    }
}
