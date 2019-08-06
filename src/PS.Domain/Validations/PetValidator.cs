﻿using FluentValidation;
using PS.Domain.Models;

namespace PS.Domain.Validations
{
    public sealed class PetValidator : AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name required");
        }
    }
}