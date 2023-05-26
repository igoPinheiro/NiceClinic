using FluentValidation;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Validator;

public class ClientValidator : AbstractValidator<NewClient>
{
    public ClientValidator()
    {
        RuleFor(x=> x.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(150);
        RuleFor(x => x.BirthDate).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
        RuleFor(x => x.Document).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        RuleFor(x => x.Phones).NotNull().NotEmpty();
        RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMorF).WithMessage("Sexo precisa ser M ou F");
        RuleFor(x => x.Address).SetValidator(new NewAddressValidator());
    }

    private bool IsMorF(string? s)
    {
        return !string.IsNullOrEmpty(s) && (s.ToUpper() == "M" || s.ToUpper() == "F");
    }
}
