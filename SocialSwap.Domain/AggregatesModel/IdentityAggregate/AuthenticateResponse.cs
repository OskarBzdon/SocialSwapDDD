using SocialSwap.Domain.AggregatesModel.UserAggregate;

namespace SocialSwap.Domain.AggregatesModel.IdentityAggregate
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            EmailAddress = user.Email;
            Token = token;
        }
    }
}
