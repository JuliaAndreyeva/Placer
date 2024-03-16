namespace Placer.Application.Helpers;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}