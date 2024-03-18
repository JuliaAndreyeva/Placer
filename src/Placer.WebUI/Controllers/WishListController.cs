using System.Security.Claims;
using AutoMapper;
using FluentResults;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Placer.Application.Common.Errors;
using Placer.Application.DTO;
using Placer.Application.DTO.ErrorResults;
using Placer.Application.Services.Interfaces;
using Placer.WebUI.Common.Errors;
using Placer.WebUI.Models;
using Placer.WebUI.ViewModels.Bookings;
using Placer.WebUI.ViewModels.WishList;

namespace Placer.WebUI.Controllers;

public class WishListController : Controller
{
    private readonly IWishListService _wishListService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateWishListViewModel> _validator;

    public WishListController(
        IWishListService wishListService,
        IMapper mapper,
        IValidator<CreateWishListViewModel> validator)
    {
        _mapper = mapper;
        _validator = validator;
        _wishListService = wishListService;
    }

    public async Task<IActionResult> GetAll()
    {
        var touristId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (touristId is null)
        {
            var userError = new UserErrors.UserNotFound();
            return View(userError.Message);
        }
        var wishListsDto = await _wishListService.GetAllAsync(touristId);

        var wishListViewModel = _mapper.Map<List<ListWishListViewModel>>(wishListsDto);

        return View("Index", wishListViewModel);

    }
    public async Task<IActionResult> Create()
    {
        var touristId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (touristId is null)
        {
            var userError = new UserErrors.UserNotFound();
            return View(userError.Message);
        }
        
        CreateWishListViewModel wishListViewModel = new CreateWishListViewModel();
        wishListViewModel.TouristId = touristId;
        
        return View(wishListViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWishListViewModel wishlistViewModel)
    {
        var validationResult = await _validator.ValidateAsync(wishlistViewModel);
        
        if(!validationResult.IsValid)
        {
            return View("ErrorResult", new UserInputError(validationResult));
        }

        var wishListDto = _mapper.Map<WishListDTO>(wishlistViewModel);
        
        var result = await _wishListService.Create(wishListDto);
        
        var resultDto = _mapper.Map<ResultDTO>(result);

        return View("CustomResult", resultDto);
    }

    // public async Task<IActionResult> AddTour(int tourId, int wishListId)
    // {
    //     //check if this tour is in that wishlist - validation
    //     //
    // }
}