
namespace Placer.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int? BookingId { get; set; }
        public string TouristId { get; set; }
        public int TourId { get; set; }
        public virtual Tourist Tourist { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual Booking? Booking { get; set; }
    }
}
