using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC.Core.Domain;

namespace NC.Data.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(k => k.ClientId);

        //builder.HasOne(p => p.Client)
        //    .WithOne(p => p.Address)
        //    .HasForeignKey<Address>(f=>f.ClientId);

    }
}
