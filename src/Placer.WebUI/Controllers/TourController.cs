using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Placer.Infrastructure.Data;

namespace Placer.WebUI.Controllers;

public class TourController : Controller
{
    private readonly PlacerCodeFirstDbContext _dbContext;

    public TourController(
        PlacerCodeFirstDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var tours = _dbContext.Tours.ToList();
        return View(tours);
    }
    public IActionResult Details(int id)
    {
        var tour = _dbContext.Tours
            .Include(x=>x.Agency)
            .Include(x=>x.Manager)
            .Include(x=>x.TourPlaces)
                .ThenInclude(x=>x.Place)
            .FirstOrDefault(x => x.Id == id);

        return default;
        //TODO : do the details page
    }

    public IActionResult GetTouristTours(string id)
    {
        var tours = _dbContext.Payments
            .Where(p => p.TouristId == id)
            .Select(p => p.Tour)
            .ToList();

        return View("TourList", tours);
    }
}