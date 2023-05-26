using FluentValidation;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Validator;

public class NewPhoneValidator : AbstractValidator<NewPhone>
{
    public NewPhoneValidator()
    {
        string FrtPhone = "[1-9][0-9]{10}";
        RuleFor(p => p.Number).Matches(FrtPhone).WithMessage("O telefone tem que ter o formato "+FrtPhone);
    }
}

