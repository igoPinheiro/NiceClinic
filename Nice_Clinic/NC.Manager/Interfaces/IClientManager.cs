using NC.Core.Domain;

namespace NC.Manager.Interfaces;

public interface IClientManager
{
    Task<Client> GetClientAsync(int id);
    Task<IEnumerable<Client>> GetClientsAsync();
}
