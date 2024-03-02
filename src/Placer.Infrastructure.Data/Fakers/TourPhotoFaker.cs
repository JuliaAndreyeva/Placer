using Bogus;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class TourPhotoFaker : Faker<TourPhoto>
{
    public TourPhotoFaker(string touristId)
    {
        RuleFor(u => u.Url, f => f.Image.PicsumUrl());
        RuleFor(u => u.CreationTime, f => f.Date.Past());
        RuleFor(u => u.TouristId, f => touristId);
        RuleFor(u => u.TourId, f => f.Random.Number(1, DataSeeder.CountToSeed));
        UseSeed(7474);
    }
}