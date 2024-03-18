using System.Data;
using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;
using Placer.WebUI.ViewModels.Agencies;
using Placer.WebUI.ViewModels.Bookings;
using Placer.WebUI.ViewModels.Managers;
using Placer.WebUI.ViewModels.Tours;
using Placer.WebUI.ViewModels.Tours;

namespace Placer.WebUI.MapperProfiles;

public class TourProfile : Profile
{
    public TourProfile()
    {
        CreateMap<TourCropViewModel, TourCropDTO>().ReverseMap();
        
        CreateMap<RecentTourDTO, RecentTourDetailsViewModel>()
            .ForMember(dest => dest.AgencyName, opt => opt.MapFrom(src => src.AgencyDTO.Name))
            .ForMember(dest => dest.ManagerName,
                opt => opt.MapFrom(src => src.ManagerDTO.FirstName + " " + src.ManagerDTO.LastName))
            .ForMember(dest => dest.TourPlaces, opt => opt.MapFrom(src => src.TourPlacesDTO))
            .ReverseMap();

        CreateMap<TourPhotoDTO, TourPhotoViewModel>();
        
        CreateMap<PastTourDetailsDTO, PastTourDetailsViewModel>()
            .ForMember(dest => dest.AgencyName, opt => opt.MapFrom(src => src.AgencyName))
            .ForMember(dest => dest.ManagerName,
                opt => opt.MapFrom(src => src.ManagerName))
            .ForMember(dest => dest.TourPhotos, opt => opt.MapFrom(src => src.TourPhotoDTO));

    }
}