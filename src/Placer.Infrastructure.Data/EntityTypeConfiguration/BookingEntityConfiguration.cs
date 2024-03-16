using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(
        EntityTypeBuilder<Booking> builder)
    {
        builder.Property(x => x.CreationTime);
        
        builder.HasOne(x => x.Tour)
            .WithMany() 
            .HasForeignKey(x => x.TourId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Booker)
            .WithMany(y => y.Bookings )
            .HasForeignKey(x => x.BookerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(t => t.Price)
            .HasColumnType("decimal(18, 2)");
        
        
    }
}