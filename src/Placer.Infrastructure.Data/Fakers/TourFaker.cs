﻿using Bogus;
using Placer.Core.Entities;
using Placer.Core.Enums;

namespace Placer.Infrastructure.Data.Fakers;

public sealed class TourFaker :Faker<Tour>
{
    public TourFaker(string managerId)
    {
        RuleFor(u => u.Name, f => f.Lorem.Word());
        RuleFor(u => u.Description, f => f.Lorem.Sentence());
        RuleFor(u => u.AgencyId, f => f.Random.Number(1, DataSeeder.CountToSeed));
        RuleFor(u => u.ManagerId, f => managerId);
        RuleFor(u => u.Price, f => f.Finance.Amount());
        RuleFor(u => u.BookingPrice, f => f.Finance.Amount());
        RuleFor(u => u.BookingLimitDays, f => f.Random.Number(1, 10));
        //RuleFor(u => u.State, f => f.PickRandom<TourState>().ToString());
        RuleFor(u => u.State, f => TourState.Planned.ToString());
        RuleFor(u => u.StartDate, f => f.Date.Past());
        RuleFor(u => u.PhotoUrl, f => f.Image.PicsumUrl());
        RuleFor(u => u.EndDate, (f, u) => f.Date.Between(u.StartDate, u.StartDate.AddMonths(1)));
        UseSeed(4555);
    }
}