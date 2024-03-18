using System.Reflection;
using FluentValidation;
using Placer.Application.MapperProfiles;
using Placer.WebUI.ViewModels.WishList;
using Placer.WebUI.ViewModelValidators.WishList;

namespace Placer.WebUI.Configuration;

public class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllersWithViews()
            .ConfigureLocalization();
        
        services.AddRazorPages();
        services.AddAutoMapper(typeof(Program).Assembly, typeof(BookingProfile).Assembly);
        services.AddScoped<IValidator<CreateWishListViewModel>, WishListCreationValidator>();
    }
}