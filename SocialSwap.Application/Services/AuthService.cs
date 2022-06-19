using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SocialSwap.Application.Providers;
using SocialSwap.Domain.AggregatesModel.IdentityAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SocialSwap.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegisterResponse> Register(RegisterRequest registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync<RegisterRequest>("users/register", registerModel);

            return await result.Content.ReadFromJsonAsync<RegisterResponse>();
        }

        public async Task<AuthenticateResponse> Login(AuthenticateRequest loginModel)
        {
            var loginAsJson = JsonSerializer.Serialize(loginModel);
            var response = await _httpClient.PostAsync("https://localhost:7000/users/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var tset = await response.Content.ReadAsStringAsync();
            var loginResult = JsonSerializer.Deserialize<JsonElement>(tset, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return new AuthenticateResponse(null, loginResult.GetProperty("token").GetString());
            }

            await _localStorage.SetItemAsync("authToken", loginResult.GetProperty("token").GetString());
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.AddressEmail);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.GetProperty("token").GetString());

            return new AuthenticateResponse(new Client { Email = loginModel.AddressEmail }, loginResult.GetProperty("token").GetString());
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
