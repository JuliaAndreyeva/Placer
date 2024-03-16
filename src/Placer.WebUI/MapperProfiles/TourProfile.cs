using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;
using Placer.WebUI.ViewModels.Bookings;
using Placer.WebUI.ViewModels.Tours;
using Placer.WebUI.ViewModels.Tours;

namespace Placer.WebUI.MapperProfiles;

public class TourProfile : Profile
{
    public TourProfile()
    {
        CreateMap<TourCropViewModel, TourCropDTO>().ReverseMap();
        CreateMap<Tour, PastTourDetailsViewModel>().ReverseMap();

        CreateMap<PastTourDTO, PastTourDetailsViewModel>()
            .ForMember(dest => dest.AgencyName, opt => opt.MapFrom(src => src.AgencyDTO.Name))
            .ForMember(dest => dest.ManagerName,
                opt => opt.MapFrom(src => src.ManagerDTO.FirstName + " " + src.ManagerDTO.LastName))
            .ForMember(dest => dest.TourPlaces, opt => opt.MapFrom(src => src.TourPlacesDTO));
    }
}