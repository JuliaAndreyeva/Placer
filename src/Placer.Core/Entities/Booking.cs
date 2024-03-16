
namespace Placer.Core.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public decimal? Price { get; set; }
        public string BookerId { get; set; }
        public int TourId { get; set; } 
        /// <summary>
        ///  The booking Duration in days is сhosen by the tourist
        /// </summary>
        public int BookingDuration { get; set; }
        public Tourist Booker { get; set; }
        public Tour Tour { get; set; }
        
    }
}
