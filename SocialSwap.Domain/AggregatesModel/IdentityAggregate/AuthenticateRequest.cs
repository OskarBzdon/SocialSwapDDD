using System.ComponentModel.DataAnnotations;

namespace SocialSwap.Domain.AggregatesModel.IdentityAggregate
{
    public class AuthenticateRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
