using AutoMapper;
using NC.Core.Domain;
using NC.Core.Shared.ModelViews;
using NC.Manager.Interfaces;

namespace NC.Manager.Implementation;

public class ClientManager : IClientManager
{
    private readonly IClientRepository clientRepository;
    private readonly IMapper mapper;

    public ClientManager(IClientRepository clientRepository, IMapper mapper)
    {
        this.clientRepository = clientRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await clientRepository.GetClientsAsync();
    }

    public async Task<Client> GetClientAsync(int id)
    {
        return await clientRepository.GetClientAsync(id);
    }

    public async Task DeleteClientAsync(int id)
    {
         await clientRepository.DeleteClientAsync(id);
    }

    public async Task<Client?> InsertClientAsync(NewClient newClient)
    {
        var client =mapper.Map<Client>(newClient);

        return await clientRepository.InsertClientAsync(client);
    }

    public async Task<Client?> UpdateClientAsync(UpdateClient updateClient)
    {
        var client = mapper.Map<Client>(updateClient);

        return await clientRepository.UpdateClientAsync(client);
    }
}
