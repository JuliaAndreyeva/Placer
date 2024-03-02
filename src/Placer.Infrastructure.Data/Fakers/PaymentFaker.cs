using Bogus;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class PaymentFaker:Faker<Payment>
{
    public PaymentFaker(string touristId)
    {
        RuleFor(u => u.Date, f => f.Date.Future());
        RuleFor(u => u.TouristId, f => touristId);
        RuleFor(u => u.TourId, f => f.Random.Number(1, DataSeeder.CountToSeed));
        UseSeed(7474);
    }
}