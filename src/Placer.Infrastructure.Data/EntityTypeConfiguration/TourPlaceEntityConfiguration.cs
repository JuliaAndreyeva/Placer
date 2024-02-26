using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class TourPlaceEntityConfiguration : IEntityTypeConfiguration<TourPlaces>
{
    public void Configure(
        EntityTypeBuilder<TourPlaces> builder)
    {
        builder.HasKey(x=> x.Id);

        builder.HasOne(x=> x.Place)
            .WithMany(x=>x.TourPlaces)
            .HasForeignKey(x => x.PlaceId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.Tour)
            .WithMany(x => x.TourPlaces)
            .HasForeignKey(x => x.TourId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}