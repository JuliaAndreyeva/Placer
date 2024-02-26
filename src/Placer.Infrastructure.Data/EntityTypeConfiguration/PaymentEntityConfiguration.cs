using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(
        EntityTypeBuilder<Payment> builder)
    {
        builder.HasOne(x => x.Tour)
            .WithMany()
            .HasForeignKey(x => x.TourId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Tourist)
            .WithMany(y => y.Payments)
            .HasForeignKey(x => x.TouristId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}