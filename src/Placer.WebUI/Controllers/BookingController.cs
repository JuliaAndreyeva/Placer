using System.Security.Claims;
using AutoMapper;
using Braintree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Placer.Application.Interfaces.Payment;
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
        
        var gateway = _paymentService.GetGateway();
        var clientToken = gateway.ClientToken.Generate(); 
        ViewBag.ClientToken = clientToken;
        
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
       
        var request = new TransactionRequest
        {
            Amount = Convert.ToDecimal(bookingViewModel.BookingPrice),
            PaymentMethodNonce = bookingViewModel.Nonce,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };
        var gateway = _paymentService.GetGateway();
        
        Result<Transaction> result = gateway.Transaction.Sale(request);

        if (!result.IsSuccess())
            return Problem("transaction failed");
        
        _dbContext.Bookings.Add(booking);
        _dbContext.SaveChangesAsync();
        return RedirectToAction("Index", "Tour");
    }
}