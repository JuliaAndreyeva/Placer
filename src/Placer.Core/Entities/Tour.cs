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
        public string ManagerId { get; set; }
        public virtual Manager Manager { get; set; }     
        public decimal Price { get; set; }   
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<TourPlaces> TourPlaces { get; set; }
        public virtual ICollection<TourPhoto> TourPhotos { get; set;}
    }
}