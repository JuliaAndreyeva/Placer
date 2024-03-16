using Placer.Application.DTO;

namespace Placer.Application.Services.Interfaces;

public interface ITourService
{
    Task<List<TourCropDTO>> GetAll();
    Task<PastTourDTO> GetPastTourDetails(int tourId);

    Task<List<TourCropDTO>> GetTouristPastTours(string touristId);
}