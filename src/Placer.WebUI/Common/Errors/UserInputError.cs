using FluentResults;
using FluentValidation.Results;

namespace Placer.WebUI.Common.Errors;

public class UserInputError : Error
{
    public UserInputError(ValidationResult validationResult)
        : base($"Incorrect input")
    {
        foreach (var error in validationResult.Errors)
        {
             Metadata.Add(error.ErrorCode, error.ErrorMessage);
        }
       
    }
}
