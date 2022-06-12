using SocialSwap.Domain.AggregatesModel.IdentityAggregate;

namespace SocialSwap.Domain.AggregatesModel.UserAggregate
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int id);
        Task<Client> SignUp(Address address, Client client);
    }
}
