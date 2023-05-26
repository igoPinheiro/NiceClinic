using FluentValidation;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Validator;

public class NewAddressValidator : AbstractValidator<NewAddress>
{
    public NewAddressValidator()
    {
        RuleFor(p => p.City).NotEmpty().NotNull().MaximumLength(200);

        RuleFor(p => p.PostalCode).NotEmpty().NotNull();
        RuleFor(p => p.UF).NotNull();
        RuleFor(p => p.City).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.Street).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.Number).NotEmpty().NotNull().MaximumLength(10);
        RuleFor(p => p.Complement).MaximumLength(200);
    }
}
