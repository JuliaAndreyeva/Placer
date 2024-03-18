using Placer.Application;
using Placer.Application.DTO;
using Placer.Application.Helpers;
using Placer.Application.Services;
using Placer.Application.Services.Interfaces;
using Placer.Application.Validators;

namespace Placer.WebUI.Configuration;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPaymentConfiguration(configuration);
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IBookingService,BookingService>();
        services.AddScoped<IValidator<CreationBookingDTO>, BookingCreationValidator>();
        services.AddScoped<ITourService, TourService>();
        services.AddScoped<IWishListService, WishListService>();
    }
}