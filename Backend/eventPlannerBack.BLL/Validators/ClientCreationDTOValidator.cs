using eventPlannerBack.Models.VModels.ClientDTO;
using FluentValidation;

namespace eventPlannerBack.BLL.Validators
{
    public class ClientCreationDTOValidator : AbstractValidator<ClientCreationDTO>
    {
        public ClientCreationDTOValidator()
        {
            
        }
    }
}
