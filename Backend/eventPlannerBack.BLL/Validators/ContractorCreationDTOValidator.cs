using eventPlannerBack.Models.VModels.ContractorDTO;
using FluentValidation;

namespace eventPlannerBack.BLL.Validators
{
    public class ContractorCreationDTOValidator : AbstractValidator<ContractorCreationDTO>
    {
        public ContractorCreationDTOValidator()
        {
            RuleFor(x => x.CUIT)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(20).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");
        }
    }
}
