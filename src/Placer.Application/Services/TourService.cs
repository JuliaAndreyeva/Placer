using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Placer.Application.DTO;
using Placer.Application.Services.Interfaces;
using Placer.Core.Entities;
using Placer.Core.Enums;
using Placer.Infrastructure.Data;

namespace Placer.Application.Services;

public class TourService : ITourService
{
    private readonly PlacerCodeFirstDbContext _dbContext;
    private readonly IMapper _mapper;

    public TourService(
        PlacerCodeFirstDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TourCropDTO>> GetAll()
    {
        var tours = await _dbContext.Tours.AsNoTracking().ToListAsync();
        
        List<TourCropDTO> listPastBookingDto = _mapper.Map<List<Tour>, List<TourCropDTO>>(tours);

        return listPastBookingDto;
    }

    public async Task<PastTourDTO> GetPastTourDetails(int tourId)
    {
        var pastTour = await _dbContext.Tours
            .Where(x=>x.Id == tourId)
            .Include(x=>x.Manager)
            .Include(x=>x.Agency)
            .AsSplitQuery()
            .Include(x=>x.TourPlaces)
                .ThenInclude(x=>x.Place)
            .FirstOrDefaultAsync();

        var pastTourDto = _mapper.Map<PastTourDTO>(pastTour);

        return pastTourDto;
    }

    public async Task<List<TourCropDTO>> GetTouristPastTours(string touristId)
    {
        var tours = await _dbContext.Payments
            .Where(p => p.TouristId == touristId)
            .Include(p => p.Tour)
            .Where(p => p.Tour.State == TourState.Finished.ToString())
            .Select(p=> p.Tour)
            .AsNoTracking()
            .ToListAsync();
        
        List<TourCropDTO> listPastToursDto = _mapper.Map<List<Tour>, List<TourCropDTO>>(tours);

        return listPastToursDto;
    }
}