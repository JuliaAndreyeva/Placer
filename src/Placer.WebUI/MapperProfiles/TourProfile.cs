using AutoMapper;
using Placer.Core.Entities;
using Placer.WebUI.ViewModels.Tour;

namespace Placer.WebUI.MapperProfiles;

public class TourProfile : Profile
{
    public TourProfile()
    {
        CreateMap<Tour, TourCropViewModel>().ReverseMap();
    }
}