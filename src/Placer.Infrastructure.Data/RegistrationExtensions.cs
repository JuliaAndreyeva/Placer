using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Placer.Infrastructure.Data;

public static class RegistrationExtensions
{
    public static void AddStorage(
        this IServiceCollection serviceCollection,
        string connectionString)
    {
        serviceCollection.AddDbContext<PlacerCodeFirstDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}