using Bogus;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class AgencyFaker :Faker<Agency>
{ 
    public AgencyFaker()
    {
        RuleFor(u => u.Name, f => f.Company.CompanyName());
        UseSeed(2022);
    }
}