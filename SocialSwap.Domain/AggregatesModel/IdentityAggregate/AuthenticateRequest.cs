using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.IdentityAggregate
{
    public class AuthenticateRequest
    {
        [Required]
        [EmailAddress]
        public string AddressEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
