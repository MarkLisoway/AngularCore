using System;
using System.Linq.Expressions;
using BusinessLogic.Validation.PropertyValidation;
using BusinessLogic.ValidationModels;
using DataAccess.Models;

namespace BusinessLogic.Validation.ModelValidation.Validators
{
    public sealed class UserModelValidator : ModelValidator<ValidationUser>
    {
        // ReSharper disable once ConvertToConstant.Local
        private static readonly string ValidationPrefix = nameof(User);

        
        public override bool ValidateCreate(ValidationUser model)
        {
            return FinalizeValidation();
        }

        
        public override bool ValidateUpdate(ValidationUser model)
        {
            model.Id.BeginValidation(ValidationPrefix, nameof(model.Id), Errors);
            
            return FinalizeValidation();
        }

        
        public override bool ValidateDelete(ValidationUser model)
        {
            
            return FinalizeValidation(true);
        }

        
        public override bool Validate(ValidationUser model)
        {
            return ValidateCreate(model);
        }
    }
}