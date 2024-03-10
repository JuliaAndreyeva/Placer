using Braintree;

namespace Placer.Application.Interfaces.Payment;

public interface IPaymentService
{
    IBraintreeGateway CreateGateway();
    IBraintreeGateway GetGateway();
    decimal CalculateBookingSum(int dayCount, decimal price);
}