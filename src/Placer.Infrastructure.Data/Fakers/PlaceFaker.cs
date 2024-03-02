using Bogus;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class PlaceFaker : Faker<Place>
{
    public PlaceFaker()
    {
        RuleFor(u => u.Name, f => f.Address.City());
        RuleFor(u => u.Description, f => f.Lorem.Sentence());
        RuleFor(u => u.Address, f => f.Address.FullAddress());
        RuleFor(u => u.Image, f => f.Image.PicsumUrl());
        UseSeed(4657);
    }
}