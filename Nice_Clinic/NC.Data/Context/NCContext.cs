using Microsoft.EntityFrameworkCore;
using NC.Core.Domain;

namespace NC.Data.Context;

public class NCContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    public NCContext(DbContextOptions options) : base (options) {
    
        
    }  
    
}
