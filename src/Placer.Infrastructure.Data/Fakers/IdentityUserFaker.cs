using Bogus;
using Microsoft.AspNetCore.Identity;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class IdentityUserFaker<TPerson> : Faker<TPerson> 
    where TPerson : IdentityUser
{
    public IdentityUserFaker()
    {
        RuleFor(u => u.UserName, f => f.Internet.Email());
        RuleFor(u => u.Email, (f, u) => u.UserName);
        RuleFor(u => u.NormalizedUserName, (f, u) => u.UserName.ToUpper());
        RuleFor(u => u.NormalizedEmail, (f, u) => u.Email.ToUpper());
        RuleFor(u => u.EmailConfirmed, f => f.Random.Bool());
        RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());
        RuleFor(u => u.PhoneNumberConfirmed, f => f.Random.Bool());
    }
}