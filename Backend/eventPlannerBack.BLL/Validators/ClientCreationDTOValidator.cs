using eventPlannerBack.Models.VModels.ClientDTO;
using FluentValidation;

namespace eventPlannerBack.BLL.Validators
{
    public class ClientCreationDTOValidator : AbstractValidator<ClientCreationDTO>
    {
        public ClientCreationDTOValidator()
        {

            RuleFor(x => x.TaxCode)
                .NotEmpty().WithMessage("The '{PropertyName}' field cannot be empty.")
                .MaximumLength(20).WithMessage("The '{PropertyName}' field must not exceed {MaxLength} characters");
        }
    }
}
