
namespace Placer.Core.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public decimal? Price { get; set; }
        public string BookerId { get; set; }
        public int TourId { get; set; } 
        public virtual Tourist Booker { get; set; }
        public virtual Tour Tour { get; set; }
        public int TimeBooked { get; set; }
    }
}
