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
    public const int CountToSeed = 10;
    private readonly Random rnd = new Random();

    public DataSeeder(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        PlacerCodeFirstDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _passwordHasher = new PasswordHasher<IdentityUser>();
        _dbContext = dbContext;
        
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
        
        var touristFaker = new IdentityUserFaker<Tourist>();
        for (int i = 0; i < CountToSeed; i++)
        {
            var fakeTourist = touristFaker.Generate();
            fakeTourist.PasswordHash = _passwordHasher.HashPassword(fakeTourist, "touristBLACKblack1*");
            await _userManager.CreateAsync(fakeTourist);
            await _userManager.AddToRoleAsync(fakeTourist, Role.Tourist.ToString());
        }

        Random rnd = new Random();
        var agencyFaker = new AgencyFaker();
        var agencies = agencyFaker.Generate(CountToSeed);
        _dbContext.Agencies.AddRange(agencies);
        
            
        var managerFaker = new IdentityUserFaker<Manager>();
        for (int i = 0, k = 1; i < CountToSeed; i++)
        {
            var fakeManager = managerFaker.Generate();
            fakeManager.PasswordHash = _passwordHasher.HashPassword(fakeManager, "managerBLACKblack1*");
            fakeManager.AgencyId = k++;
            await _userManager.CreateAsync(fakeManager);
            await _userManager.AddToRoleAsync(fakeManager, Role.Manager.ToString());
        }
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
        
         _dbContext.Places.AddRange(placeFaker.Generate(CountToSeed));
        _dbContext.Tours.AddRange(tourFaker.Generate(CountToSeed));
        _dbContext.TourPhotos.AddRange(tourPhotoFaker.Generate(CountToSeed));
        _dbContext.TourPlaces.AddRange(tourPlacesFaker.Generate(CountToSeed));
        _dbContext.WishLists.AddRange(wishListFaker.Generate(CountToSeed));
        _dbContext.Bookings.AddRange(bookingFaker.Generate(CountToSeed));
        _dbContext.Payments.AddRange(paymentFaker.Generate(CountToSeed));
    }
    private string GetRandomManagerId()
    {
        var managerIds = _dbContext.Managers.Select(x => x.Id).ToList();
        return managerIds.OrderBy(x => rnd.Next()).FirstOrDefault();
    }

    private string GetRandomTouristId()
    {
        var touristIds = _dbContext.Tourists.Select(x => x.Id).ToList();
        return touristIds.OrderBy(x => rnd.Next()).FirstOrDefault();
    }
}