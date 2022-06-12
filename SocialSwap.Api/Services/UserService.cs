using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialSwap.Api.Providers;
using SocialSwap.Domain.AggregatesModel.IdentityAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;

namespace SocialSwap.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = await _repo.Authenticate(model);

            if (user == null) return null;

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repo.Index();
        }

        public async Task<User> Get(int id)
        {
            return await _repo.Get(id);
        }

        public Task<Client> SignUp(Address address, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
