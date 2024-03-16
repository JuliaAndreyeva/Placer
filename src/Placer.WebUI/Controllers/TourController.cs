using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Placer.Application.DTO;
using Placer.Application.Services.Interfaces;
using Placer.Infrastructure.Data;
using Placer.WebUI.ViewModels.Tours;

namespace Placer.WebUI.Controllers;

public class TourController : Controller
{
    private readonly IMapper _mapper;
    private readonly ITourService _tourService;

    public TourController(
        IMapper mapper,
        ITourService tourService)
    {
        _mapper = mapper;
        _tourService = tourService;
    }

    public async Task<ActionResult> Index()
    {
        var toursDto = await _tourService.GetAll();
        
        List<TourCropViewModel> tourViewModels = _mapper.Map<List<TourCropDTO>, List<TourCropViewModel>>(toursDto);
        
        return View(tourViewModels);
    }
    public async Task<IActionResult> GetPastTourDetails(int tourId)
    {
        var tour = await _tourService.GetPastTourDetails(tourId);
        
        var pastTourViewModel = _mapper.Map<PastTourDetailsViewModel>(tour);
        
        return View("PastTourDetails", pastTourViewModel);
    }

    public async Task<IActionResult> GetTouristPastTours(string touristId)
    {
        var toursDto = await _tourService.GetTouristPastTours(touristId);
        
        List<TourCropViewModel> tourViewModels = _mapper.Map<List<TourCropDTO>, List<TourCropViewModel>>(toursDto);

        return View("TourList", tourViewModels);
    }
}