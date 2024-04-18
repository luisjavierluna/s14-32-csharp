using eventPlannerBack.Models.VModels;
using FluentValidation;

namespace eventPlannerBack.BLL.Validators
{
    public class UserCredentialsDTOValidator : AbstractValidator<UserCredentialsDTO>
    {
        public UserCredentialsDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .EmailAddress().WithMessage("The field '{PropertyName}' must be a valid email address")
                .MaximumLength(100).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(50).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");
        }
    }
}
