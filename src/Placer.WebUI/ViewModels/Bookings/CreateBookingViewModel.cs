using Placer.Core.Entities;

namespace Placer.WebUI.ViewModels.Bookings;

public class CreateBookingViewModel
{
    public int TourId { get; set; }
    public string? PhotoUrl { get; set; }
    public decimal TourPrice { get; set; }   
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? BookingPrice { get; set; }
    public int? BookingLimitDays { get; set; }
    public string BookerId { get; set; }
    public int BookingDuration { get; set; }
    public string Nonce { get; set; } = string.Empty;
}