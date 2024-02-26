using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    public class Tourist : AppUser
    {
        //IEnumerable<Tour> LikedTours { get; set;  }
        //public int TourInId { get; set; }
        //public virtual Tour TourIn { get; set; }
        public ICollection<TourPhoto> TourPhotos { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<WishList> WishLists { get; set; }

    }
}
