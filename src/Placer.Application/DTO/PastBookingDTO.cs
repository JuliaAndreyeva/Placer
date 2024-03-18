namespace Placer.Application.DTO;

public class PastBookingDTO
{
    public DateTime CreationTime { get; set; } 
    public decimal BookingPrice { get; set; }
    public int TourId { get; set; }
    public int BookingDuration { get; set; }
}