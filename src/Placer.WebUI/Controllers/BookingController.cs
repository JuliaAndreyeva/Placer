using System.Security.Claims;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Placer.Application.Common.Errors;
using Placer.Application.DTO;
using Placer.Application.DTO.ErrorResults;
using Placer.Application.Services.Interfaces;
using Placer.Application.Validators;
using Placer.Core.Enums;
using Placer.Infrastructure.Data;
using Placer.WebUI.ViewModels.Bookings;

namespace Placer.WebUI.Controllers;

public class BookingController : Controller
{
    private readonly IMapper _mapper;
    private readonly PlacerCodeFirstDbContext _dbContext;
    private readonly IPaymentService _paymentService;
    private readonly IBookingService _bookingService;
    private readonly IValidator<CreationBookingDTO> _validator;

    public BookingController(
        IMapper mapper,
        PlacerCodeFirstDbContext dbContext,
        IPaymentService paymentService,
        IBookingService bookingService,
        IValidator<CreationBookingDTO> validator)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _paymentService = paymentService;
        _bookingService = bookingService;
        _validator = validator;
    }
    public async Task<IActionResult> Create(int id)
    {
        var bookingDetailsDto = await _bookingService.GetBookingTourDetailsAsync(id);
        
        var bookerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (bookerId is null)
        {
            var userError = new UserErrors.UserNotFound();
            return View(userError.Message);
        }

        Result validationResult = await _validator.ValidateAsync(bookingDetailsDto);
        
        if (validationResult.IsFailed)
        {
            var resultDto = _mapper.Map<ResultDTO>(validationResult);
            return View("CustomError", resultDto);
        }
        
        var tourBookingDetailsViewModel = _mapper.Map<CreateBookingViewModel>(bookingDetailsDto);

        ViewBag.ClientToken = _paymentService.GenerateClientToken();

        return View(tourBookingDetailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingViewModel bookingViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(bookingViewModel);
        }
        
        var bookingDto = _mapper.Map<CreationBookingDTO>(bookingViewModel);
         
        Result bookingResult  = await _bookingService.Book(bookingDto);

        if (bookingResult.IsFailed)
        {
            var resultDto = _mapper.Map<ResultDTO>(bookingResult);
            return View("CustomError", resultDto);
        }
        
        return RedirectToAction("Index", "Tour");
    }

    public async Task<IActionResult> GetRecentBookingsList(string touristId)
    {
        var listBookingDto = await _bookingService.GetRecentBookingAsync(touristId);

        List<ListRecentBookingsViewModel> listBookingsViewModels = _mapper.Map<List<RecentBookingDTO>, List<ListRecentBookingsViewModel>>(listBookingDto);

        return View("RecentBookings",listBookingsViewModels);
    }
    public async Task<IActionResult> GetPastBookingsList(string touristId)
    {
        var bookings = await _bookingService.GetPastBookingAsync(touristId);

        var listBookingsViewModel = _mapper.Map<List<ListPastBookingsViewModel>>(bookings);

        return View("PastBookings",listBookingsViewModel); 
    }
}