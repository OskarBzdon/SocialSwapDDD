using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSwap.Domain.AggregatesModel.IdentityAggregate
{
    public static class UserRoles
    {
        public static readonly IEnumerable<string> Roles = Enum.GetNames(typeof(eRoles)).ToList();
    }

    [Flags]
    public enum eRoles
    {
        User = 1 << 0,
        Moderator = 1 << 1,
        Administrator = 1 << 2
    }
}
