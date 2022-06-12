namespace SocialSwap.Domain.AggregatesModel.UserAggregate
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<Client> SignUp(Address address, Client client);
    }
}
