using NC.Core.Domain;

namespace NC.Manager.Interfaces;

public interface IClientRepository
{
    Task DeleteClientAsync(int id);
    Task<Client> GetClientAsync(int id);
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client?> InsertClientAsync(Client client);
    Task<Client?> UpdateClientAsync(Client client);
}
