using Microsoft.EntityFrameworkCore;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data
{
    internal class PlacerCodeFirstDbContext : DbContext
    {
        public PlacerCodeFirstDbContext()
            : base()
        {
        }
        public PlacerCodeFirstDbContext(
            DbContextOptions options)
            : base(options)
        {
        }
        
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<TourPhoto> TourPhotos { get; set; }
        public DbSet<TourPlaces> TourPlaces { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlacerCodeFirstDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}