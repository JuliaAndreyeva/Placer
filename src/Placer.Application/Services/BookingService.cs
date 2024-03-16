using AutoMapper;
using Braintree;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Placer.Application.Common.Errors;
using Placer.Application.DTO;
using Placer.Application.Helpers;
using Placer.Application.Services.Interfaces;
using Placer.Application.Validators;
using Placer.Infrastructure.Data;
using Placer.Core.Entities;
using Placer.Core.Enums;

namespace Placer.Application.Services;

public class BookingService : IBookingService
{
    private readonly IPaymentService _paymentService;
    private readonly PlacerCodeFirstDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IDateTimeProvider _provider;

    public BookingService(
        IPaymentService paymentService,
        PlacerCodeFirstDbContext dbContext,
        IMapper mapper,
        IDateTimeProvider provider)
    {
        _paymentService = paymentService;
        _dbContext = dbContext;
        _mapper = mapper;
        _provider = provider;
    }
    public async Task<Result> Book(CreationBookingDTO creationBookingDto)
    {
        creationBookingDto.BookingPrice = CalculateBookingSum(creationBookingDto.BookingDuration, creationBookingDto.BookingPrice);

        var resultTransaction = _paymentService.CreateTransaction(creationBookingDto.BookingPrice, creationBookingDto.Nonce);
        
        if (!resultTransaction.IsSuccess())
        {
            return Result.Fail(new PaymentErrors.TransactionFailed());
        }
        
        var booking = _mapper.Map<Booking>(creationBookingDto);
        booking.CreationTime = _provider.UtcNow;

        try
        {
            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Result.Fail(new PersistanceErrors.SavingFailed().CausedBy(ex));
        }
        return Result.Ok();
    }
    private decimal CalculateBookingSum(int dayCount, decimal price )
    {
        return price * dayCount;
    }
    public async Task<CreationBookingDTO> GetBookingTourDetailsAsync(int tourId)
    {
        var bookingDetails = await _dbContext.Tours
            .Where(x => x.State == TourState.Planned.ToString())
            .Include(x => x.TourPlaces)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == tourId);

        var bookingDetailsDto = _mapper.Map<CreationBookingDTO>(bookingDetails);

        return bookingDetailsDto;
    }
    public async Task<List<RecentBookingDTO>> GetRecentBookingAsync(string bookerId)
    {
        var listRecentBooking = await _dbContext.Bookings
            .Where(x => x.BookerId == bookerId)
            .Include(x => x.Tour)
            .Where(x => x.Tour.State == TourState.Planned.ToString())
            .AsNoTracking()
            .ToListAsync();
        
        List<RecentBookingDTO> listRecentBookingDto = _mapper.Map<List<Booking>, List<RecentBookingDTO>>(listRecentBooking);

        foreach (var recentBookingDto in listRecentBookingDto)
        {
            recentBookingDto.BookingDeadline = GetEndBookingDate(recentBookingDto.BookingDuration, recentBookingDto.CreationTime);
        }
        return listRecentBookingDto;
    }
    private DateTime GetEndBookingDate(int bookingDuration, DateTime creationTime)
    {
        return creationTime.AddDays(bookingDuration);
    }
    public async Task<List<PastBookingDTO>> GetPastBookingAsync(string bookerId)
    {
        var listPastBooking = await _dbContext.Bookings
            .Where(x=>x.BookerId == bookerId)
            .Include(x => x.Tour)
            .Where(x => x.Tour.State != TourState.Planned.ToString())
            .AsNoTracking()
            .ToListAsync();
        
        List<PastBookingDTO> listPastBookingDto = _mapper.Map<List<Booking>, List<PastBookingDTO>>(listPastBooking);

        return listPastBookingDto;
    }
}