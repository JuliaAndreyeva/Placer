using Placer.Application.DTO;

namespace Placer.Application.Services.Interfaces;

public interface ITourService
{
    Task<List<TourCropDTO>> GetAll();
    Task<RecentTourDTO> GetTourDetails(int tourId);
    Task<List<TourCropDTO>> GetTouristPastTours(string touristId);
    Task<PastTourDetailsDTO> GetPastTourDetails(int tourId);
}