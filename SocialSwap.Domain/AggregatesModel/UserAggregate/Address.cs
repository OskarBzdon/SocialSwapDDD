using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.UserAggregate
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Postcode { get; set; }
        public string Street { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }

        public virtual ICollection<Client> Residents { get; set; }
    }
}
