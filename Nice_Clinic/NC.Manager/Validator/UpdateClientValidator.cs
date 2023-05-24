using FluentValidation;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Validator;

public class UpdateClientValidator : AbstractValidator<UpdateClient>
{
    public UpdateClientValidator()
    {
        RuleFor(p=>p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new ClientValidator());
    }
}
