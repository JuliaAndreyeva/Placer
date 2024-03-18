using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Placer.Application.Common.Errors;
using Placer.Application.Common.Successes;
using Placer.Application.DTO;
using Placer.Application.Services.Interfaces;
using Placer.Core.Entities;
using Placer.Infrastructure.Data;

namespace Placer.Application.Services;

public class WishListService : IWishListService
{
    private readonly PlacerCodeFirstDbContext _dbContext;
    private readonly IMapper _mapper;

    public WishListService(
        PlacerCodeFirstDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<List<WishListDTO>> GetAllAsync(string touristId)
    {
        var wishlists = await _dbContext.WishLists
            .Where(x=>x.TouristId == touristId)
            .AsNoTracking()
            .ToListAsync();
        
        List<WishListDTO> listWishlistsDto = _mapper.Map<List<WishList>, List<WishListDTO>>(wishlists);

        return listWishlistsDto;
    }
    public async Task<Result> Create(WishListDTO wishListDto)
    {
        var wishList = _mapper.Map<WishList>(wishListDto);

        try
        {
            await _dbContext.WishLists.AddAsync(wishList);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Fail(new PersistanceErrors.SavingFailed().CausedBy(ex));
        }

        return Result.Ok().WithSuccess(new CreationSuccess(wishList.Name));
    }
}