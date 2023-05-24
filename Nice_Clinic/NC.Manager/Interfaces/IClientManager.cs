using NC.Core.Domain;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Interfaces;

public interface IClientManager
{
    Task DeleteClientAsync(int id);
    Task<Client> GetClientAsync(int id);
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client?> InsertClientAsync(NewClient client);
    Task<Client?> UpdateClientAsync(UpdateClient client);
}
