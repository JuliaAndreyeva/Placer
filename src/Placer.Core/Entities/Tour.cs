using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Placer.Core.Enums;

namespace Placer.Core.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }     
        public decimal Price { get; set; }   
        public TourState State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<TourPlaces> TourPlaces { get; set; }
        public ICollection<TourPhoto> TourPhotos { get; set;}
    }
}