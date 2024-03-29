﻿using Braintree;
using Microsoft.Extensions.Options;
using Placer.Application.Services.Interfaces;
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
    public string GenerateClientToken()
    {
        var gateway = GetGateway();
        
        return gateway.ClientToken.Generate(); 
    }
    public Result<Transaction> CreateTransaction(decimal count, string nonce)
    {
        var request = new TransactionRequest
        {
            Amount = Convert.ToDecimal(count),
            PaymentMethodNonce = nonce,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };
        var gateway = GetGateway();
        
        Braintree.Result<Transaction> result = gateway.Transaction.Sale(request);
        
        return result;
    }
}