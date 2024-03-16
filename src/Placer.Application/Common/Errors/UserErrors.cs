using FluentResults;

namespace Placer.Application.Common.Errors;

public class UserErrors
{
    public class UserNotFound : Error
    {
        public UserNotFound()
            : base($"User not found")
        { 
            Metadata.Add("ErrorCode", "Claims didn't found");
        }
    }
}
