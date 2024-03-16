using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class PlaceProfile : Profile
{
    public PlaceProfile()
    {
        CreateMap<PlaceDTO, Place>().ReverseMap();
    }
}