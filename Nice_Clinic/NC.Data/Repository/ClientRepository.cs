using Microsoft.EntityFrameworkCore;
using NC.Core.Domain;
using NC.Data.Context;
using NC.Manager.Interfaces;

namespace NC.Data.Repository;

public class ClientRepository : IClientRepository
{
    private readonly NCContext context;

    public ClientRepository(NCContext context)
    {
        this.context = context;
    }

    //O método de extensão AsNoTracking() retorna uma nova consulta e as
    //entidades retornadas não serão armazenadas em cache pelo contexto (DbContext).
    //Isto significa que o Entity Framework não efetua qualquer processamento ou
    //armazenamento adicional das entidades que são devolvidos pela consulta.
    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await context.Clients.AsNoTracking().ToListAsync();
    }

    public async Task<Client?> GetClientAsync(int id)
    {
        return await context.Clients.FindAsync(id);
        //return await context.Clients.AsNoTracking().FirstOrDefaultAsync(f => f.Id==id);
        // return await context.Clients.AsNoTracking().Where(w=> w.Id == id).FirstOrDefaultAsync();
    }
}
