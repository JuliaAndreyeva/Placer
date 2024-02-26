using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration
{
    internal class TourEntityConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(
            EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(tour => tour.Manager)
                .WithMany(manager => manager.Tours)
                .HasForeignKey(tour => tour.ManagerId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(e => e.Manager)
                .WithMany(e => e.Tours)
                .HasForeignKey(e => e.ManagerId)
                .IsRequired();
            builder.Property(t => t.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
