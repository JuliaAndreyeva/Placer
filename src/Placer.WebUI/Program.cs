using Microsoft.Extensions.Options;
using Placer.Infrastructure.Data;
using Placer.WebUI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices(builder.Configuration,
        typeof(IServiceInstaller).Assembly);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    //await app.DatabaseEnsureCreated();
    //await app.SeedData();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tour}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
