using eventPlannerBack.Models.VModels.EventsDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Validators
{
    public  class EventCreationDTOValidator : AbstractValidator<EventCreationDTO>
    {
        public EventCreationDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MinimumLength(3).WithMessage("The '{PropertyName}' field must have at least {MinLength} characters")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");
        }
    }
}
