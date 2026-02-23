using SecureCientDataManagementFrontend.Models;

namespace SecureCientDataManagementFrontend.Interfaces
{
    public interface IClientApiService
    {
        Task AddClientAsync(ClientDto dto);
        Task<List<Client>> GetClientsAsync();
        Task<string> DecryptEmiratesIdAsync(int id);
    }
}