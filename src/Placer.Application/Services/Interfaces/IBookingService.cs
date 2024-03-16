using FluentResults;
using Placer.Application.DTO;

namespace Placer.Application.Services.Interfaces;

public interface IBookingService
{
    public Task<Result> Book(CreationBookingDTO creationBookingDto);
    Task<CreationBookingDTO> GetBookingTourDetailsAsync(int tourId);
    Task<List<RecentBookingDTO>> GetRecentBookingAsync(string bookerId);
    Task<List<PastBookingDTO>> GetPastBookingAsync(string bookerId);
}
    