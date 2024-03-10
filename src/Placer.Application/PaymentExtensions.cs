using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Placer.Application.Interfaces.Payment;
using Placer.Application.Services;
using Placer.Application.Utils;

namespace Placer.Application;

public static class PaymentExtensions
{
    public static void AddPaymentCongiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<BrainTreeSettings>(configuration.GetSection("BrainTreeSettings"));
        services.AddSingleton<IPaymentService, PaymentService>();
    }
}