using SecureCientDataManagementAPI.Models;

namespace SecureCientDataManagementAPI.Repositories
{
    public class InMemoryClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = new();
        private int _nextId = 1;

        public Task AddClientAsync(Client client)
        {
            client.Id = _nextId++;
            _clients.Add(client);
            return Task.CompletedTask;
        }

        public Task<List<Client>> GetAllAsync()
        {
            return Task.FromResult(new List<Client>(_clients));
        }

        public Task<Client?> GetByIdAsync(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(client);
        }
    }
}