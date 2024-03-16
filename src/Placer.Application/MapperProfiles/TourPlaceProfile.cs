using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class TourPlaceProfile : Profile
{
    public TourPlaceProfile()
    {
        CreateMap<PastTourPlaceDTO, TourPlaces>()
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
            .ReverseMap();
    }
}