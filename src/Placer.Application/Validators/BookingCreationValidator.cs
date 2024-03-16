using FluentResults;
using Microsoft.EntityFrameworkCore;
using Placer.Application.Common.Errors;
using Placer.Application.DTO;
using Placer.Infrastructure.Data;

namespace Placer.Application.Validators;

public class BookingCreationValidator : IValidator<CreationBookingDTO>
{
    private PlacerCodeFirstDbContext _dbContext { get; set; }

    public BookingCreationValidator(
        PlacerCodeFirstDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> ValidateAsync(
        CreationBookingDTO creationBookingDto)
    {
        bool havePastTours = _dbContext.Payments
            .Any(x => x.TouristId == creationBookingDto.BookerId);

        if (havePastTours is true)
        {
            var datesBookedTour = await _dbContext.Tours
                .Where(x => x.Id == creationBookingDto.TourId)
                .Select(x => new { StartDate = x.StartDate, EndDate = x.EndDate })
                .FirstOrDefaultAsync();

            bool isOverlap = await _dbContext.Payments
                .Where(p => p.TouristId == creationBookingDto.BookerId)
                .Include(p => p.Tour)
                .AnyAsync(p =>
                    (p.Tour.StartDate <= datesBookedTour.EndDate && p.Tour.EndDate >= datesBookedTour.StartDate)
                );

            if (isOverlap is true)
            {
                return Result.Fail(new TourErrors.TourOverlap());
            }
        }
        return Result.Ok();
    }
}