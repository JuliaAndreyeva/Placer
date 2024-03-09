using Placer.Application.Interfaces;

namespace Placer.Application.Services;

public class PaymentService: IPaymentService
{
    public decimal CalculateBookingSum(int dayCount, decimal price )
    {
        return price * dayCount;
    }
    
}