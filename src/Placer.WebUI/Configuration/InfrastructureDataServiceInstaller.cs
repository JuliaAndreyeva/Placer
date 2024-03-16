using Microsoft.AspNetCore.Identity;
using Placer.Infrastructure.Data;

namespace Placer.WebUI.Configuration;

public class InfrastructureDataServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (connectionString != null) 
            services.AddStorage(connectionString);
        
        services.AddDefaultIdentity<IdentityUser>(
                options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PlacerCodeFirstDbContext>();
    }
}