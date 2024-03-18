using AutoMapper;
using Placer.Application.DTO;
using Placer.WebUI.ViewModels.WishList;

namespace Placer.WebUI.MapperProfiles;

public class WishListProfile : Profile
{
    public WishListProfile()
    {
        CreateMap<WishListDTO, ListWishListViewModel>();
        CreateMap<CreateWishListViewModel, WishListDTO>();
    }
}