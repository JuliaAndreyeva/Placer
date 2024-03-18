using FluentValidation;
using Placer.WebUI.ViewModels.WishList;

namespace Placer.WebUI.ViewModelValidators.WishList;

public class WishListCreationValidator : AbstractValidator<CreateWishListViewModel>
{
    public WishListCreationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(1, 30);
    }
}