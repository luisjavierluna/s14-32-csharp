using FluentValidation;

namespace eventPlannerBack.BLL.Behaviors
{
    public class ValidationBehavior<T>
    {
        private readonly IValidator<T> _validator;

        public ValidationBehavior(IValidator<T> validator)
        {
            this._validator = validator;
        }

        public async Task ValidateFields(T model)
        {
            var validator = await _validator.ValidateAsync(model);

            if (!validator.IsValid)
            {
                var errors = validator.Errors.ToList();

                throw new ValidationException(errors);
            }
        }
    }
}
