using SocialSwap.Domain.AggregatesModel.IdentityAggregate;
using System.Text.Json;

namespace SocialSwap.Application.Pages
{
    public partial class Signin
    {
        public AuthenticateRequest Model { get; set; } = new AuthenticateRequest();
        public AuthenticateResponse response { get; set; }
        //public async void OnValidSubmit()
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get,
        //    "https://localhost:7000/api/signin");
        //    request.Headers.Add("Accept", "application/json");
        //    request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

        //    var client = ClientFactory.CreateClient();

        //    var response = await client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        response = await JsonSerializer.DeserializeAsync
        //            <AuthenticateResponse>(responseStream);
        //    }
        //}
    }
}
