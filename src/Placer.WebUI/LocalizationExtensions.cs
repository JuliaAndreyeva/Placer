using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

namespace Placer.WebUI;

public static class LocalizationExtensions
{
    public static void ConfigureLocalization(this IServiceCollection services)
    {         
        services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

        var cultureEn = new CultureInfo("en-US");
        var cultureUk = new CultureInfo("uk-UA");

        var supportedCultures = new[] { cultureEn, cultureUk};

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.SetDefaultCulture(cultureUk.Name);
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.FallBackToParentCultures = false;
        });

        services.AddControllersWithViews()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

    }
}