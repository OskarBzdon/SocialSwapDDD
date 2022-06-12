using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using SocialSwap.Infrastructure.DataSources;

namespace SocialSwap.Api.Services
{
    public class UserService : IUserService
    {
        private readonly SocialSwapContext _ctx;
        public UserService(SocialSwapContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            User user = _ctx.Clients.FirstOrDefault(f => f.EmailAddress.Equals(username));

            if (user == null)
            {
                return null;
            }

            string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(user.Salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10,
                numBytesRequested: 256 / 8));

            if (!user.HashedPassword.Equals(passwordHash))
            {
                return null;
            }

            // on auth fail: null is returned because user is not found
            // on auth success: user object is returned
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // wrapped in "await Task.Run" to mimic fetching users from a db
            return await Task.Run(() => _ctx.Clients.ToListAsync());
        }

        public async Task<Client> SignUp(Address address, Client client)
        {
            await _ctx.Addresses.AddAsync(address);
            await _ctx.Clients.AddAsync(client);
            client.Address = address;
            await _ctx.SaveChangesAsync();
            return client;
        }
    }
}
