using FluentResults;

namespace Placer.Application.DTO.ErrorResults;

public class ResultDTO
{ 
    public ICollection<ErrorDTO> ErrorsDTO { get; set; }
    public ICollection<SuccessDTO> SuccessDTO { get; set; }
}