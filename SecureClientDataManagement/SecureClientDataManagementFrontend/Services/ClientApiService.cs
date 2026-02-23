using SecureCientDataManagementFrontend.Interfaces;
using SecureCientDataManagementFrontend.Models;
using System.Net.Http.Json;

namespace SecureCientDataManagementFrontend.Services
{
    public class ClientApiService : IClientApiService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl = "http://api:80/api/Clients";  

        public ClientApiService(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task AddClientAsync(ClientDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var response = await _http.PostAsJsonAsync(_baseUrl, dto);

            response.EnsureSuccessStatusCode(); // agar fail ho toh exception throw karega
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            var clients = await _http.GetFromJsonAsync<List<Client>>(_baseUrl);
            return clients ?? new List<Client>();
        }

        public async Task<string> DecryptEmiratesIdAsync(int id)
        {
            var response = await _http.GetAsync($"{_baseUrl}/{id}/decrypt");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Decrypt failed with status {response.StatusCode}: {errorContent}");
        }
    }
}