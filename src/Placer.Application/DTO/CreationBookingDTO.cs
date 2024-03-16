using Placer.Core.Entities;

namespace Placer.Application.DTO;

public class CreationBookingDTO
{
    public int Id { get; set; }
    public decimal TourPrice { get; set; }
    
    public DateTime CreationTime { get; set; }
    public decimal BookingPrice { get; set; }
    public string BookerId { get; set; }
    public int TourId { get; set; }
    public int BookingDuration { get; set; }
    public string Nonce { get; set; }
}