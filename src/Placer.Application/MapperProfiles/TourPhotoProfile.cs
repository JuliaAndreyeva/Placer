using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class TourPhotoProfile: Profile
{
    public TourPhotoProfile()
    {
        CreateMap<TourPhoto, TourPhotoDTO>().ReverseMap();
    }
}