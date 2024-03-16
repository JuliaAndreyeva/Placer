using FluentResults;

namespace Placer.Application.Validators;

public interface IValidator<T>
{
    Task<Result> ValidateAsync(T dto);
}