using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Placer.Infrastructure.Data;
using Placer.WebUI.ViewModels.Tour;

namespace Placer.WebUI.Controllers;

public class TourController : Controller
{
    private readonly PlacerCodeFirstDbContext _dbContext;
    private readonly IMapper _mapper;

    public TourController(
        PlacerCodeFirstDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var tours = _dbContext.Tours.ToList();
        
        var tourViewModels = _mapper.Map<List<TourCropViewModel>>(tours);
        
        return View(tourViewModels);
    }
    public IActionResult Details(int id)
    {
        var tour = _dbContext.Tours
            .Include(x=>x.Agency)
            .Include(x=>x.Manager)
            .Include(x=>x.TourPlaces)
                .ThenInclude(x=>x.Place)
            .FirstOrDefault(x => x.Id == id);
      
        return default;  //in progress
    }

    public IActionResult GetTouristTours(string id)
    {
        var tours = _dbContext.Payments
            .Where(p => p.TouristId == id)
            .Select(p => p.Tour)
            .ToList();
        
        var tourViewModels = _mapper.Map<List<TourCropViewModel>>(tours);

        return View("TourList", tourViewModels);
    }
}