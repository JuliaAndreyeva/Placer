using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class TourPhotoEntityConfiguration : IEntityTypeConfiguration<TourPhoto>
{
    public void Configure(
        EntityTypeBuilder<TourPhoto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Url)
            .IsRequired();

        builder.HasOne(x=> x.Tourist)
            .WithMany(x=>x.TourPhotos)
            .HasForeignKey(x => x.TouristId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.Tour)
            .WithMany(x => x.TourPhotos)
            .HasForeignKey(x => x.TourId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}