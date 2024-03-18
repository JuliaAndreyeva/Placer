using FluentResults;
using Placer.Application.DTO;

namespace Placer.Application.Services.Interfaces;

public interface IWishListService
{
    Task<List<WishListDTO>> GetAllAsync(string touristId);

    Task<Result> Create(WishListDTO wishListDto);
}