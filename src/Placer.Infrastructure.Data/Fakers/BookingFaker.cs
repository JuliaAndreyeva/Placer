using Bogus;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class BookingFaker: Faker<Booking>
{
    public BookingFaker(string bookerId)
    {
        RuleFor(u => u.CreationTime, f =>  f.Date.Past());
        RuleFor(u => u.Price, f => f.Finance.Amount());
        RuleFor(u => u.BookerId, f => bookerId);
        RuleFor(u => u.TourId, f => f.Random.Number(1, DataSeeder.CountToSeed));
        RuleFor(u => u.DaysTimeBooked, f => f.Random.Number(1, 10));
        UseSeed(7574);
    }
}