using SecureCientDataManagementAPI.Models;

namespace SecureCientDataManagementAPI.Interfaces
{
    public interface IClientService
    {
        Task AddClientAsync(ClientDto dto);
        Task<List<Client>> GetAllClientsAsync();
        Task<string> GetDecryptedEmiratesIdAsync(int id);
    }
}