using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialSwap.Domain.AggregatesModel.UserAggregate;

namespace SocialSwap.Infrastructure.Configurations
{
    public class AddressEFConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var addresses = new List<Address>();
            addresses.Add(new Address
            {
                Id = "1",
                Country = "Poland",
                City = "Warsaw",
                Postcode = "00-110",
                Street = "Street1",
                BuildingNumber = "1"
            });
            addresses.Add(new Address
            {
                Id = "2",
                Country = "Poland",
                City = "Warsaw",
                Postcode = "00-120",
                Street = "Street2",
                BuildingNumber = "2"
            });
            addresses.Add(new Address
            {
                Id = "3",
                Country = "Poland",
                City = "Warsaw",
                Postcode = "00-130",
                Street = "Street3",
                BuildingNumber = "3"
            });

            //builder.HasData(addresses);
        }
    }
}
