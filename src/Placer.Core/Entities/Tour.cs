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
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }     
        public double Price { get; set; }   
        public bool Available { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        IEnumerable<TourPlaces> TourPlaces { get; set; }
        IEnumerable<TourPhoto> TourPhotos { get; set;}
    }
}