using FluentResults;

namespace Placer.Application.Common.Errors;

public class PersistanceErrors
{
    public class SavingFailed : Error
    {
        public SavingFailed()
            : base($"Internal server error")
        { 
            Metadata.Add("ErrorCode", "Saving");
        }
    }
}