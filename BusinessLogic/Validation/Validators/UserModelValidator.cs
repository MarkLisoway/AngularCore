using BusinessLogic.Validation.PropertyValidation;
using DataAccess.Models;

namespace BusinessLogic.Validation.Validators
{
    public sealed class UserModelValidator : ModelValidatorBase<User>
    {
        // ReSharper disable once ConvertToConstant.Local
        private static readonly string ValidationPrefix = nameof(User);

        
        public override bool ValidateCreate(User model)
        {
            model.Id.BeginValidation(ValidationPrefix, nameof(model.Id), Errors)
                .MustBeDefault();

            model.Name.BeginValidation(ValidationPrefix, nameof(model.Name), Errors)
                .CannotBeNull()
                .CannotBeEmpty();
            
            return FinalizeValidation();
        }

        
        public override bool ValidateUpdate(User model)
        {
            model.Id.BeginValidation(ValidationPrefix, nameof(model.Id), Errors)
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
            model.Id.BeginValidation(ValidationPrefix, nameof(model.Id), Errors)
                .CannotBeNull()
                .CannotBeDefault()
                .MustBeGreaterThanOrEqualTo(1);
            
            return FinalizeValidation(true);
        }

        
        public override bool Validate(User model)
        {
            return ValidateCreate(model);
        }
    }
}