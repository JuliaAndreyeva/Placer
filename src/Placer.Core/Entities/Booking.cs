using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class Booking
    {
        public int Id { get; set; }
        public int BookerId { get; set; }
        public int TourId { get; set; } 
        public virtual Tourist Booker { get; set; }
        public virtual Tour Tour { get; set; }
        public int TimeBooked { get; set; }
    }
}
