using DataAccess.Models;

namespace BusinessLogic.Validation.Validators
{
    public class UserValidator : ValidatorBase<User>
    {
        public override bool Validate(User model)
        {
            model.Name.StartValidations(Errors, nameof(model.Name))
                .CannotBeNullOrEmpty();

            return FinalizeValidation();
        }
    }
}