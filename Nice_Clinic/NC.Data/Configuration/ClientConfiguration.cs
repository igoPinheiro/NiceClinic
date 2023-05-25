using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC.Core.Domain;

namespace NC.Data.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);
        //builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        //builder.Property(p => p.Sexo).HasDefaultValue("M").IsRequired();

        builder.HasIndex(x => new { x.Name, x.Sexo });
    }
}
