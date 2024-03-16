using Microsoft.AspNetCore.Identity;
using Placer.Core.Entities;
using Placer.Core.Enums;
using Placer.Infrastructure.Data.Fakers;

namespace Placer.Infrastructure.Data;

public class DataSeeder
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly PasswordHasher<IdentityUser> _passwordHasher;
    private readonly PlacerCodeFirstDbContext _dbContext;
    public  static int CountToSeed;
    private readonly Random rnd = new Random();
    private List<string> managerIds = new List<string>();
    private List<string> touristIds = new List<string>();

    public DataSeeder(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        PlacerCodeFirstDbContext dbContext,
        int countToSeed)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _passwordHasher = new PasswordHasher<IdentityUser>();
        _dbContext = dbContext;
        CountToSeed = countToSeed;
    }
    public async Task SeedRoleData()
    {
        foreach (Role role in Enum.GetValues(typeof(Role)))
        {
            IdentityRole identityRole = new IdentityRole() { Name = role.ToString() };

            var roleExist = await _roleManager.RoleExistsAsync(identityRole.Name);

            if (!roleExist)
                await _roleManager.CreateAsync(identityRole);
        }
    }

    public async Task SeedUsersData()
    {
        var identityUserFaker = new IdentityUserFaker<IdentityUser>();
        var fakeAdmin = identityUserFaker.Generate();
        fakeAdmin.PasswordHash = _passwordHasher.HashPassword(fakeAdmin, "BLACKblack1*");
        await _userManager.CreateAsync(fakeAdmin);
        await _userManager.AddToRoleAsync(fakeAdmin, Role.Admin.ToString());

        var touristFaker = new IdentityUserFaker<Tourist>()
            .RuleFor(u=> u.FirstName, f=>f.Name.FirstName())
            .RuleFor(u=> u.LastName, f=>f.Name.LastName());
        
        for (int i = 0; i < CountToSeed; i++)
        {
            var fakeTourist = touristFaker.Generate();
            touristIds.Add(fakeTourist.Id);
            fakeTourist.PasswordHash = _passwordHasher.HashPassword(fakeTourist, "touristBLACKblack1*");
            await _userManager.CreateAsync(fakeTourist);
            await _userManager.AddToRoleAsync(fakeTourist, Role.Tourist.ToString());
        }
        
        var agencyFaker = new AgencyFaker();
        var agencies = agencyFaker.Generate(CountToSeed);
        _dbContext.Agencies.AddRange(agencies);

        var managerFaker = new IdentityUserFaker<Manager>()
            .RuleFor(u=> u.FirstName, f=>f.Name.FirstName())
            .RuleFor(u=> u.LastName, f=>f.Name.LastName());
        
        for (int i = 0, k = 1; i < CountToSeed; i++)
        {
            var fakeManager = managerFaker.Generate();
            managerIds.Add(fakeManager.Id);
            fakeManager.PasswordHash = _passwordHasher.HashPassword(fakeManager, "managerBLACKblack1*");
            fakeManager.AgencyId = k++;
            await _userManager.CreateAsync(fakeManager);
            await _userManager.AddToRoleAsync(fakeManager, Role.Manager.ToString());
        }

        await _dbContext.SaveChangesAsync();
    }
    public async Task SeedEntities()
    {
        var placeFaker = new PlaceFaker();
        var tourFaker = new TourFaker(GetRandomManagerId()); //will change it later so as not to make constant calls to the database
        var tourPhotoFaker = new TourPhotoFaker(GetRandomTouristId());
        var tourPlacesFaker = new TourPlaceFaker();
        var wishListFaker = new WishListFaker(GetRandomTouristId());
        var bookingFaker = new BookingFaker(GetRandomTouristId());
        var paymentFaker = new PaymentFaker(GetRandomTouristId());

        var places = placeFaker.Generate(CountToSeed);
        _dbContext.Places.AddRange(places);

        var tours = tourFaker.Generate(CountToSeed);
        _dbContext.Tours.AddRange(tours);
        await _dbContext.SaveChangesAsync();

        var tourPhotos = tourPhotoFaker.Generate(CountToSeed);
        _dbContext.TourPhotos.AddRange(tourPhotos);

        var tourPlaces = tourPlacesFaker.Generate(CountToSeed);
        _dbContext.TourPlaces.AddRange(tourPlaces);
        
        for (int i = 0; i < CountToSeed; i++)
        {
            var wishList = wishListFaker.Generate();
            wishList.Tours = tours.Take(i).ToList();
            _dbContext.WishLists.Add(wishList);
        }

        var bookings = bookingFaker.Generate(CountToSeed);
        _dbContext.Bookings.AddRange(bookings);

        var payments = paymentFaker.Generate(CountToSeed);
        _dbContext.Payments.AddRange(payments);
        
        await _dbContext.SaveChangesAsync();
    }
    private string GetRandomManagerId()
    {
        return managerIds.ElementAt(rnd.Next(CountToSeed));
    }
    
    private string GetRandomTouristId()
    {
        return touristIds.ElementAt(rnd.Next(CountToSeed));
    }
}