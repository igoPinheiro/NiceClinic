using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC.Core.Domain;

namespace NC.Data.Configuration;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.HasKey(k => new { k.ClientId, k.Number });

        builder
            .HasOne(o => o.Client)
            .WithMany(c => c.Phones)
            .IsRequired()
            .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
    }
}
