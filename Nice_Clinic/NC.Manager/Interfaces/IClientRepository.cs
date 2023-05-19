using NC.Core.Domain;

namespace NC.Manager.Interfaces;

public interface IClientRepository
{
    Task<Client> GetClientAsync(int id);
    Task<IEnumerable<Client>> GetClientsAsync();
}
