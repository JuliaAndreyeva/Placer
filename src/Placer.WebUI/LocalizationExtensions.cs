using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

namespace Placer.WebUI;

public static class LocalizationExtensions
{
    public static void ConfigureLocalization(this IMvcBuilder builder)
    { 
        builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

        var cultureEn = new CultureInfo("en-US");
        var cultureUk = new CultureInfo("uk-UA");

        var supportedCultures = new[] { cultureEn, cultureUk};

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            options.SetDefaultCulture(cultureEn.Name);
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.FallBackToParentCultures = false;
        });
        
        builder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

    }
}