using Placer.Core.Entities;

namespace Placer.WebUI.ViewModels.Bookings;

public class ListRecentBookingsViewModel
{
    public int Id { get; set; }
    public DateTime CreationTime { get; set; }
    public decimal? BookingPrice { get; set; }
    public DateTime BookingDeadline { get; set; }
    public int TourId { get; set; }
}