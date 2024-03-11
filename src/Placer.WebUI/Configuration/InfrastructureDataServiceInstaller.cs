using Placer.Infrastructure.Data;

namespace Placer.WebUI.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (connectionString != null) 
            services.AddStorage(connectionString);
    }
}