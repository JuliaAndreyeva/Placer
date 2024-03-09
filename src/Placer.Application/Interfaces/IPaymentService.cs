namespace Placer.Application.Interfaces;

public interface IPaymentService
{
    decimal CalculateBookingSum(int dayCount, decimal price);
}