using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;


public class ManagerEntityConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(
        EntityTypeBuilder<Manager> builder)
    {
        //builder.Property(x => x.Id).UseIdentityColumn(2, 3);
        builder.ToTable("Managers");
        builder.HasOne(e => e.Agency)
            .WithMany(e => e.Managers)
            .HasForeignKey(e => e.AgencyId)
            .IsRequired();
    }
}