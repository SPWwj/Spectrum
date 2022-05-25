using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Spectrum.Shared.Models;
using System.Net.Http.Json;

namespace Spectrum.Client.ApiClients
{
    public class PortalClient
    {
        private readonly HttpClient _httpClient;

        public PortalClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApplicationUser?> GetUserAndPortals() =>
            await _httpClient.GetFromJsonAsync<ApplicationUser>("/api/portal");
        public async Task<bool> RemovePortal(string portalId)
        {
            var response = await _httpClient.DeleteAsync("/api/portal/" + portalId);
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<bool> UpdatePortal(SpectrumPortal portal)
        {
            var response = await _httpClient.PutAsJsonAsync("api/portal", portal);
            response.EnsureSuccessStatusCode();
            return true;
        }
        public async Task<bool> AddPortal(SpectrumPortal portal)
        {
            var response = await _httpClient.PostAsJsonAsync("api/portal", portal);
            response.EnsureSuccessStatusCode();
            return true;

        }


    }
}
