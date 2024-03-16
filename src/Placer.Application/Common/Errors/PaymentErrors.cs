using FluentResults;

namespace Placer.Application.Common.Errors;

public static class PaymentErrors
{
    public class TransactionFailed : Error
    {
        public TransactionFailed()
            : base($"Transaction failed")
        { 
            Metadata.Add("ErrorCode", "Transaction failing");
        }
    }
}