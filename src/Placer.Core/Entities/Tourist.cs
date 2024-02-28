
using Microsoft.AspNetCore.Identity;

namespace Placer.Core.Entities
{
    public class Tourist : IdentityUser
    {
        public virtual ICollection<TourPhoto> TourPhotos { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }

    }
}
