using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialSwap.Api.Providers;
using SocialSwap.Domain.AggregatesModel.IdentityAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using SocialSwap.Infrastructure.DataSources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialSwap.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialSwapContext _ctx;
        private readonly AppSettingsProvider _appSettings;

        public UserRepository(SocialSwapContext ctx, IOptions<AppSettingsProvider> appSettings)
        {
            _ctx = ctx;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = _ctx.Clients.FirstOrDefault(x => x.Email.Equals(model.AddressEmail.ToLower()));
            if (user == null) return null;
            var hashPassword = GenerateHash(model.Password, user!.Salt);

            if (!hashPassword.Equals(user.PasswordHash)) return null;

            var token = GenerateJwtToken(user);

            var result = new AuthenticateResponse(user, token);
            return result;
        }

        public User Create(User entity)
        {
            throw new NotImplementedException();
        }

        public User Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Index(string? selfId = null)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private string GenerateHash(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: Convert.FromBase64String(salt),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10,
                    numBytesRequested: 256 / 8));
        }
    }
}
