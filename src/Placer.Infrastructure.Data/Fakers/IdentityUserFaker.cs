using Bogus;
using Microsoft.AspNetCore.Identity;

namespace Placer.Infrastructure.Data.Fakers;

public class IdentityUserFaker<TPerson> : Faker<TPerson> 
    where TPerson : IdentityUser
{
    public IdentityUserFaker()
    {
        RuleFor(u => u.UserName, f => f.Internet.UserName());
        RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.UserName));
        RuleFor(u => u.NormalizedUserName, (f, u) => u.UserName.ToUpper());
        RuleFor(u => u.NormalizedEmail, (f, u) => u.Email.ToUpper());
        RuleFor(u => u.EmailConfirmed, f => f.Random.Bool());
        RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());
        RuleFor(u => u.PhoneNumberConfirmed, f => f.Random.Bool());
    }
}