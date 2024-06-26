﻿using eventPlannerBack.Models.VModels;
using FluentValidation;

namespace eventPlannerBack.BLL.Validators
{
    public class UserCreationDTOValidator : AbstractValidator<UserCreationDTO>
    {
        public UserCreationDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .EmailAddress().WithMessage("The field '{PropertyName}' must be a valid email address")
                .MaximumLength(100).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(100).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(100).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(50).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(50).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters")
                .Equal(p => p.Password).WithMessage("The '{PropertyName}' field must be equal to field Password");

            RuleFor(x => x.ProfileImage)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(100).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(10).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

        }
    }
}
