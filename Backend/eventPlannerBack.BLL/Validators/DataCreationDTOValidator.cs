using eventPlannerBack.Models.VModels.DatosDTO;
using FluentValidation;

namespace eventPlannerBack.BLL.Validators
{
    public class DataCreationDTOValidator : AbstractValidator<DataCreationDTO>
    {
        public DataCreationDTOValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(45).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(45).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(250).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.DNI)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(45).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(45).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");

        }
    }
}
