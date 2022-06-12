using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SocialSwap.Domain.AggregatesModel.ConversationAggregate;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace SocialSwap.Domain.AggregatesModel.UserAggregate
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [JsonIgnore]
        public string HashedPassword { get; set; }
        [Required]
        [JsonIgnore]
        public string Salt { get; set; }
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public DateTime RefreshTokenExpirationDate { get; set; }

        public virtual ICollection<Conversation> Conversations { get; set; }

        public static AuthStruct HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return new AuthStruct
            {
                Hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10,
                    numBytesRequested: 256 / 8)),
                RefreshToken = new Guid().ToString(),
                RefreshTokenExpirationDate = DateTime.Now.AddDays(7),
                Salt = Convert.ToBase64String(salt)
            };
        }

        public struct AuthStruct
        {
            public string Hash { get; set; }
            public string RefreshToken { get; set; }
            public DateTime RefreshTokenExpirationDate { get; set; }
            public string Salt { get; set; }
        }
    }
}
