using BusinessLogic.Validation.PropertyValidation;
using DataAccess.Models;

namespace BusinessLogic.Validation.Validators
{
    public sealed class UserModelValidator : ModelValidatorBase<User>
    {
        private static readonly string _validationPrefix = nameof(User);
        
        public override bool ValidateCreate(User model)
        {
            return FinalizeValidation();
        }

        public override bool ValidateUpdate(User model)
        {
            model.Id.BeginValidation(_validationPrefix, nameof(model.Id), Errors)
                .IfThen(true, validations => validations
                    .CannotBeNull())
                .MustBeDefault()
                .MustBeGreaterThan(12)
                .CannotBeNull()
                .MustBeLessThan(30)
                .MustBeGreaterThanOrEqualTo(12)
                .MustBeLessThanOrEqualTo(30);

            return FinalizeValidation();
        }

        public override bool ValidateDelete(User model)
        {
            return FinalizeValidation(true);
        }

        public override bool Validate(User model)
        {
            return ValidateCreate(model);
        }
    }
}