using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class WishListEntityConfiguration : IEntityTypeConfiguration<WishList>
{
    public void Configure(
        EntityTypeBuilder<WishList> builder)
    {
        builder.HasOne(w => w.Tourist)
            .WithMany(t => t.WishLists)
            .HasForeignKey(w => w.TouristId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(w => w.Tours)
            .WithMany()
            .UsingEntity(j => j.ToTable("WishListTours"));
    }
}