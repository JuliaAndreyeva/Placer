using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class WishListProfile : Profile
{
    public WishListProfile()
    {
        CreateMap<WishList, WishListDTO>().ReverseMap();
    }
}