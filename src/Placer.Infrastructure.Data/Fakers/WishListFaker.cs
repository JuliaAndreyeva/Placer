using Bogus;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class WishListFaker : Faker<WishList>
{
    public WishListFaker(string touristId)
    {
        RuleFor(u => u.Name, f => f.Lorem.Word());
        RuleFor(u => u.TouristId, f => touristId);
        UseSeed(5657);
    }
}