using SecureCientDataManagementAPI.Models;

namespace SecureCientDataManagementAPI.Repositories
{
    public interface IClientRepository
    {
        Task AddClientAsync(Client client);
        Task<List<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
    }
}