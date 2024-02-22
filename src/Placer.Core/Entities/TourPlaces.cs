using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class TourPlaces
    {
        public int TourId { get; set; }
        public int PlaceId { get; set; }    
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public Tour Tour { get; set; }  
        public Place Place { get; set; }

    }
}
