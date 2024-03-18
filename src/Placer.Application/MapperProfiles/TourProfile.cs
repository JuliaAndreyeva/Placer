using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class TourProfile : Profile
{
    public TourProfile()
    {
        CreateMap<Tour, TourCropDTO>().ReverseMap();
        
        CreateMap<RecentTourDTO, Tour>()
            .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src.AgencyDTO))
            .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.ManagerDTO))
            .ForMember(dest => dest.TourPlaces, opt => opt.MapFrom(src => src.TourPlacesDTO))
            .ReverseMap();

        CreateMap<Tour, PastTourDetailsDTO>()
            .ForMember(dest => dest.AgencyName, opt => opt.MapFrom(src => src.Agency.Name))
            .ForMember(dest => dest.ManagerName,
                opt => opt.MapFrom(src => src.Manager.FirstName + " " + src.Manager.LastName))
            .ForMember(dest => dest.TourPhotoDTO, opt => opt.MapFrom(src => src.TourPhotos));
    }
}