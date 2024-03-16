using Braintree;

namespace Placer.Application.Services.Interfaces;

public interface IPaymentService
{
    IBraintreeGateway CreateGateway();
    IBraintreeGateway GetGateway();
    string GenerateClientToken();
    Result<Transaction> CreateTransaction(decimal count, string nonce);
}