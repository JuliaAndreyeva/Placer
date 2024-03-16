
using Microsoft.AspNetCore.Identity;

namespace Placer.Core.Entities
{
    public class Tourist : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<TourPhoto> TourPhotos { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<WishList> WishLists { get; set; }

    }
}
