using eventPlannerBack.Models.VModels.VocationDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Validators
{
    public class VocationCreationDTOValidator : AbstractValidator<VocationCreationDTO>
    {
        public VocationCreationDTOValidator() 
        { 
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MinimumLength(3).WithMessage("The '{PropertyName}' field must have at least {MinLength} characters")
                .MaximumLength(150).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MinimumLength(3).WithMessage("The '{PropertyName}' field must have at least {MinLength} characters")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");



        }

    }
}
