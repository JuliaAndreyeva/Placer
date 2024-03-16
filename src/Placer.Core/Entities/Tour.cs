using Placer.Core.Enums;

namespace Placer.Core.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public string ManagerId { get; set; }
        public Manager Manager { get; set; }     
        public decimal Price { get; set; }   
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhotoUrl { get; set; }
        /// <summary>
        /// This is price for booking only for 1 day
        /// </summary>
        public decimal BookingPrice { get; set; }
        /// <summary>
        /// The maximum number of booking days for this tour
        /// </summary>
        public int BookingLimitDays { get; set; }
        public ICollection<TourPlaces> TourPlaces { get; set; }
        public ICollection<TourPhoto> TourPhotos { get; set;}
    }
}