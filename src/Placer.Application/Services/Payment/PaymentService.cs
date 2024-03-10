using Braintree;
using Microsoft.Extensions.Options;
using Placer.Application.Interfaces;
using Placer.Application.Interfaces.Payment;
using Placer.Application.Utils;

namespace Placer.Application.Services;

public class PaymentService: IPaymentService
{
    private BrainTreeSettings _options { get; set; }
    private IBraintreeGateway BraintreeGateway { get; set; }

    public PaymentService(
        IOptions<BrainTreeSettings> options)
    {
        _options = options.Value;
    }
    public IBraintreeGateway CreateGateway()
    {
        return new BraintreeGateway(_options.Environment, _options.MerchantId, _options.PublicKey, _options.PrivateKey);
    }
    public IBraintreeGateway GetGateway()
    {
        return BraintreeGateway ?? (BraintreeGateway = CreateGateway());
    }
    public decimal CalculateBookingSum(int dayCount, decimal price )
    {
        return price * dayCount;
    }
}