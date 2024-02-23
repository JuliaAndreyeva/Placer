using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class Payment
    {
        public int Id { get; set; }
        public int TouristId { get; set; }
<<<<<<< HEAD
        public int TourId { get; set; }
        public virtual Tourist Tourist { get; set; }
        public virtual Tour Tour { get; set; }
=======
        public Tourist Tourist { get; set; }
>>>>>>> b958e4fe32a276ea9f350e5c917c0ba7a036e4bd
    }
}
