namespace Placer.Application.DTO;

public class RecentBookingDTO
{
    public int Id { get; set; }
    public DateTime CreationTime { get; set; }
    public decimal BookingPrice { get; set; }
    public int TourId { get; set; }
    public int BookingDuration { get; set; }
    public DateTime BookingDeadline { get; set; }
}