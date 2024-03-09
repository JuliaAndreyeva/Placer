using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Placer.Application.Interfaces;
using Placer.Core.Entities;
using Placer.Infrastructure.Data;
using Placer.WebUI.ViewModels.Booking;

namespace Placer.WebUI.Controllers;

public class BookingController : Controller
{
    private readonly IMapper _mapper;
    private readonly PlacerCodeFirstDbContext _dbContext;
    private readonly IPaymentService _paymentService;

    public BookingController(
        IMapper mapper,
        PlacerCodeFirstDbContext dbContext,
        IPaymentService paymentService)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _paymentService = paymentService;
    }
    public IActionResult Create(int id)
    {
        var bookingDetails = _dbContext.Tours
            .Include(x => x.TourPlaces)
            .FirstOrDefault(x => x.Id == id);
        
        var tourBookingDetails = _mapper.Map<CreateBookingViewModel>(bookingDetails);
        
        tourBookingDetails.BookerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        return View(tourBookingDetails);
    }

    [HttpPost]
    public IActionResult Create(CreateBookingViewModel bookingViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(bookingViewModel);
        }
        
        bookingViewModel.BookingPrice = _paymentService.CalculateBookingSum(bookingViewModel.BookingDuration, bookingViewModel.TourPrice);
        
        var booking = _mapper.Map<Booking>(bookingViewModel);
        
        _dbContext.Bookings.Add(booking);
        _dbContext.SaveChangesAsync();
        
        return RedirectToAction("Index", "Tour");
    }
}