using AutoMapper;
using FluentResults;
using Placer.Application.DTO.ErrorResults;

namespace Placer.Application.MapperProfiles;

public class ResultProfile : Profile
{
    public ResultProfile()
    {
        CreateMap<Error, ErrorDTO>()
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
        
        CreateMap<Success, SuccessDTO>()
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));

        CreateMap<Result, ResultDTO>()
            .ForMember(dest => dest.ErrorsDTO, opt => opt.MapFrom(src => src.Errors))
            .ForMember(dest => dest.SuccessDTO, opt => opt.MapFrom(src => src.Successes));

    }
}