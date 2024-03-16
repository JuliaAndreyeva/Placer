using FluentResults;

namespace Placer.Application.Common.Errors;

public class TourErrors
{
    public class TourOverlap : Error
    {
        public TourOverlap()
            : base($"You can't book this tour")
        { 
            Metadata.Add("ErrorCode", "TimeTourOverlapping");
        }
    }
}