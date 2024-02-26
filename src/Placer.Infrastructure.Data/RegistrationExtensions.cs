using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Placer.Infrastructure.Data;

public static class RegistrationExtensions
{
    public static void AddStorage(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<PlacerCodeFirstDbContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            
        });

    }
}