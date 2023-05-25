using Microsoft.EntityFrameworkCore;
using NC.Core.Domain;
using NC.Data.Configuration;

namespace NC.Data.Context;

public class NCContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Address> Address { get; set; }

    public NCContext(DbContextOptions options) : base (options) {
    
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
    }
}
