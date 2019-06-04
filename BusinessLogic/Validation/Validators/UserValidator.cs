using DataAccess.Models;

namespace BusinessLogic.Validation.Validators
{
    public sealed class UserValidator : ValidatorBase<User>
    {
        public override bool ValidateCreate(User model)
        {
            model.Id.StartValidations(Errors, nameof(model.Id))
                .MustBeDefault();
            model.Name.StartValidations(Errors, nameof(model.Name))
                .CannotBeNullOrEmpty();

            return FinalizeValidation();
        }

        public override bool ValidateUpdate(User model)
        {
            model.Name.StartValidations(Errors, nameof(model.Name))
                .CannotBeNullOrEmpty();

            return FinalizeValidation();
        }

        public override bool ValidateDelete(User model)
        {
            model.Id.StartValidations(Errors, nameof(model.Id))
                .MustBeGreaterThanOrEqualTo(1);
            
            return FinalizeValidation(true);
        }

        public override bool Validate(User model)
        {
            return ValidateCreate(model);
        }
    }
}