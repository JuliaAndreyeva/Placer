using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Placer.Application.DTO;
using Placer.Application.Services;
using Placer.Application.Services.Interfaces;
using Placer.Application.Utils;
using Placer.Application.Validators;

namespace Placer.Application;

public static class PaymentExtensions
{
    public static void AddPaymentConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<BrainTreeSettings>(configuration.GetSection("BrainTreeSettings"));
        services.AddSingleton<IPaymentService, PaymentService>();
    }
}