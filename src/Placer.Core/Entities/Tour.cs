using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Agency Agency { get; set; }
        public Tourist Manager { get; set; }     
        public double Price { get; set; }   
        public bool Available { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        IEnumerable<TourPlaces> TourPlaces { get; set; }
        IEnumerable<TourPhoto> TourPhotos { get; set;}
    }
}