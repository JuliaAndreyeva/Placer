using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class TourProfile : Profile
{
    public TourProfile()
    {
        CreateMap<Tour, TourCropDTO>().ReverseMap();
        
        CreateMap<PastTourDTO, Tour>()
            .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src.AgencyDTO))
            .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.ManagerDTO))
            .ForMember(dest => dest.TourPlaces, opt => opt.MapFrom(src => src.TourPlacesDTO))
            .ReverseMap();
    }
}