using SecureCientDataManagementAPI.Interfaces;
using SecureCientDataManagementAPI.Models;
using SecureCientDataManagementAPI.Repositories;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    private readonly IEncryptionService _encryption;

    public ClientService(IClientRepository repository, IEncryptionService encryption)
    {
        _repository = repository;
        _encryption = encryption;
    }

    public async Task AddClientAsync(ClientDto dto)
    {
        var encrypted = _encryption.Encrypt(dto.EmiratesId);
        var client = new Client
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            EncryptedEmiratesId = encrypted
        };
        await _repository.AddClientAsync(client);
    }

    public async Task<List<Client>> GetAllClientsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<string> GetDecryptedEmiratesIdAsync(int id)
    {
        var client = await _repository.GetByIdAsync(id);
        if (client == null) throw new KeyNotFoundException("Client not found");

        return _encryption.Decrypt(client.EncryptedEmiratesId);
    }
}