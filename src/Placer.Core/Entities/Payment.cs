
namespace Placer.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int? BookingId { get; set; }
        public string TouristId { get; set; }
        public int TourId { get; set; }
        public Tourist Tourist { get; set; }
        public Tour Tour { get; set; }
        public Booking? Booking { get; set; }
    }
}
