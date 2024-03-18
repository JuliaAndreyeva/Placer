using FluentResults;

namespace Placer.Application.Common.Successes;


public class CreationSuccess : Success
{
    public CreationSuccess(string Name)
        :base($"You created {Name} successfully")
    {
        
    }
}