using eventPlannerBack.Models.VModels.NotificationDTO;
using FluentValidation;

namespace eventPlannerBack.BLL.Validators
{
    public class NotificationCreationDTOValidator : AbstractValidator<NotificationCreationDTO>
    {
        public NotificationCreationDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.RedirectionLink)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");
        }
    }
}
