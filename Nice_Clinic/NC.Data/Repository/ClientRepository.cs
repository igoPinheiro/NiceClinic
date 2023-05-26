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
        return await context.Clients
            .Include(i => i.Address)
            .Include(t => t.Phones)
            .AsNoTracking().ToListAsync();
    }

    public async Task<Client?> GetClientAsync(int id)
    {
        var r = await context.Clients
            .Include(i=> i.Address)
            .Include(t => t.Phones)
            .SingleOrDefaultAsync(p=> p.Id == id);
       // var r = await context.Clients.FindAsync(id);

        return r ?? null;
        //return await context.Clients.AsNoTracking().FirstOrDefaultAsync(f => f.Id==id);
        // return await context.Clients.AsNoTracking().Where(w=> w.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Client?> InsertClientAsync(Client client)
    {
        await context.Clients.AddAsync(client);
        await context.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> UpdateClientAsync(Client client)
    {
        var c = await GetClientAsync(client.Id);        

        if(c == null)
            return null;

        client.CreationDate = c.CreationDate;

        context.Entry(c).CurrentValues.SetValues(client);
        //context.Clients.Update(c);
        await context.SaveChangesAsync();
        return c;
    }

    public async Task DeleteClientAsync(int id)
    {
        var c = await GetClientAsync(id);
        if(c == null) return;
        context.Clients.Remove(c);
        await context.SaveChangesAsync();
    }
}
