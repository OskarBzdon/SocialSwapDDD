using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.Security.Cryptography;

namespace SocialSwap.Infrastructure.Configurations
{
    public class ClientEFConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            #region seed
            var clients = new List<Client>();

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            clients.Add(new Client()
            {
                Id = "1",
                Name = "CName1",
                Surname = "CSurname1",
                Birthdate = new DateTime(1990, 1, 1),
                PhoneNumber = "111111111",
                Email = "login1@test.test",
                PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: "password1",
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10,
                    numBytesRequested: 256 / 8)),
                RefreshToken = new Guid().ToString(),
                RefreshTokenExpirationDate = DateTime.Now.AddDays(7),
                Salt = Convert.ToBase64String(salt)
            });
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            clients.Add(new Client()
            {
                Id = "2",
                Name = "CName2",
                Surname = "CSurname2",
                Birthdate = new DateTime(1990, 2, 1),
                PhoneNumber = "222222222",
                Email = "login2@test.test",
                PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: "password2",
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10,
                    numBytesRequested: 256 / 8)),
                RefreshToken = new Guid().ToString(),
                RefreshTokenExpirationDate = DateTime.Now.AddDays(7),
                Salt = Convert.ToBase64String(salt)
            });
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            clients.Add(new Client()
            {
                Id = "3",
                Name = "CName3",
                Surname = "CSurname3",
                Birthdate = new DateTime(1990, 3, 1),
                PhoneNumber = "333333333",
                Email = "login3@test.test",
                PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: "password3",
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10,
                    numBytesRequested: 256 / 8)),
                RefreshToken = new Guid().ToString(),
                RefreshTokenExpirationDate = DateTime.Now.AddDays(7),
                Salt = Convert.ToBase64String(salt)
            });
            //builder.HasData(clients);
            #endregion

        }
    }
}
