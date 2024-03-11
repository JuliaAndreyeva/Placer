using Placer.Application;

namespace Placer.WebUI.Configuration;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPaymentCongiguration(configuration);
    }
}