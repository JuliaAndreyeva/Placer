using AutoMapper;
using Placer.Application.DTO;
using Placer.WebUI.ViewModels.Tours;

namespace Placer.WebUI.MapperProfiles;

public class PlaceProfile : Profile
{
    public PlaceProfile()
    {
        CreateMap<PlaceDTO, PlaceViewModel>();
        CreateMap<RecentTourPlaceDTO, TourPlaceViewModel>();
    }
}