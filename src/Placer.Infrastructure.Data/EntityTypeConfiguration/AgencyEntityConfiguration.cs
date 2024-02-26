using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class AgencyEntityConfiguration : IEntityTypeConfiguration<Agency>
{
    public void Configure(
        EntityTypeBuilder<Agency> builder)
    {
        builder
            .HasMany(e => e.Tours)
            .WithOne(e => e.Agency)
            .HasForeignKey(e => e.AgencyId)
            .IsRequired();
        
        builder
            .HasMany(e => e.Managers)
            .WithOne(e => e.Agency)
            .HasForeignKey(e => e.AgencyId)
            .IsRequired();
    }
}