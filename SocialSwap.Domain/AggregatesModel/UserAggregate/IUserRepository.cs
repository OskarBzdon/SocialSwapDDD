using SocialSwap.Domain.AggregatesModel.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSwap.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository : ICrudRepository<User>
    {
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
