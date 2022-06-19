using SocialSwap.Domain.AggregatesModel.IdentityAggregate;

namespace SocialSwap.Application.Services
{
    public interface IAuthService
    {
        public Task<RegisterResponse> Register(RegisterRequest registerModel);
        public Task<AuthenticateResponse> Login(AuthenticateRequest loginModel);
        public Task Logout();
    }
}