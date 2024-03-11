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
        services.AddAutoMapper(typeof(Program).Assembly);
    }
}