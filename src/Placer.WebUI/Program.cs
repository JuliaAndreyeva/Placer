using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Placer.Application;
using Placer.Infrastructure.Data;
using Placer.WebUI;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'PlacerCodeFirstDbContextConnection' not found.");

builder.Services.ConfigureLocalization();
builder.Services.AddPaymentCongiguration(builder.Configuration);
builder.Services.AddStorage(connectionString);

builder.Services.AddDefaultIdentity<IdentityUser>(
        options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PlacerCodeFirstDbContext>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddRazorPages();

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
