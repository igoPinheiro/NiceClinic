﻿using FluentValidation;
using NC.Core.Domain;

namespace NC.Manager.Validator;

public class ClientValidator : AbstractValidator<Client>
{
    public ClientValidator()
    {
        string FrtPhone = "[1-9][0-9]{10}";

        RuleFor(x=> x.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(150);
        RuleFor(x => x.BirthDate).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
        RuleFor(x => x.Document).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        RuleFor(x => x.Phone).NotNull().NotEmpty().Matches(FrtPhone).WithMessage("O telefone tem que ter o formato "+FrtPhone);
        RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMorF).WithMessage("Sexo precisa ser M ou F");
    }

    private bool IsMorF(string? s)
    {
        return !string.IsNullOrEmpty(s) && (s.ToUpper() == "M" || s.ToUpper() == "F");
    }
}
