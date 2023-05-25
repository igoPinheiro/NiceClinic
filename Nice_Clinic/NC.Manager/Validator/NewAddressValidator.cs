using FluentValidation;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Validator;

public class NewAddressValidator : AbstractValidator<NewAddress>
{
    public NewAddressValidator()
    {
        RuleFor(p => p.City).NotEmpty().NotNull().MaximumLength(200);
    }
}
