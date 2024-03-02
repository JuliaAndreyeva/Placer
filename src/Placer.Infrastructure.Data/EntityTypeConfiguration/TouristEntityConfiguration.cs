using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class TouristEntityConfiguration: IEntityTypeConfiguration<Tourist>
{
    public void Configure(
        EntityTypeBuilder<Tourist> builder)
    {
        builder.ToTable("Tourists");
        
        builder.HasMany(e => e.WishLists)
            .WithOne(e => e.Tourist)
            .HasForeignKey(e => e.TouristId)
            .IsRequired();
    }
}