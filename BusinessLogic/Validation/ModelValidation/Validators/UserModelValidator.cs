using System;
using System.Linq.Expressions;
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
            model.Id.BeginValidation(ValidationPrefix, nameof(model.Id), Errors)
                .MustBeDefault();

            model.Name.BeginValidation(ValidationPrefix, nameof(model.Name), Errors)
                .CannotBeNull()
                .CannotBeEmpty();
            
            return FinalizeValidation();
        }

        
        public override bool ValidateUpdate(User model, params Expression<Func<User, object>>[] updatedProperties)
        {
            var set = updatedProperties.GetSquashedUpdatePropertySet();
            
            model.Id.BeginValidation(ValidationPrefix, nameof(model.Id), Errors)
                .CannotBeNull()
                .CannotBeDefault()
                .MustBeGreaterThanOrEqualTo(1);

            model.Name.BeginValidation(ValidationPrefix, nameof(model.Name), Errors)
                .IfThen(!string.IsNullOrEmpty(model.Name), name => name
                    .CannotBeDefault());

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