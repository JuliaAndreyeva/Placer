using Bogus;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class TourPlaceFaker: Faker<TourPlaces>
{
    public TourPlaceFaker()
    {
        RuleFor(u => u.StartTime, f => f.Date.Between(DateTime.Now, DateTime.Now.AddMonths(6)));
        RuleFor(u => u.EndTime, (f, u) => f.Date.Between(u.StartTime, u.StartTime.AddMonths(1)));
        RuleFor(u => u.TourId, f => f.Random.Number(1, DataSeeder.CountToSeed));
        RuleFor(u => u.PlaceId, f => f.Random.Number(1, DataSeeder.CountToSeed));
        UseSeed(4675);
    }
}