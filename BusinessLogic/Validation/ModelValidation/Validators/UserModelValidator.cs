
using BusinessLogic.Validation.PropertyValidation;
using DataAccess.Models;

namespace BusinessLogic.Validation.ModelValidation.Validators
{
    public sealed class UserModelValidator : ModelValidator<User>
    {
        // ReSharper disable once ConvertToConstant.Local
        private static readonly string ValidationPrefix = nameof(User);

        
        public override bool ValidateCreate(User model)
        {
            return FinalizeValidation();
        }

        
        public override bool ValidateUpdate(User model)
        {
            model.Id.BeginValidation(ValidationPrefix, nameof(model.Id), Errors);
            
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