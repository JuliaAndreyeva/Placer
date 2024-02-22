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
        public Tourist Booker { get; set; }
        public int TimeBooked { get; set; }
    }
}
