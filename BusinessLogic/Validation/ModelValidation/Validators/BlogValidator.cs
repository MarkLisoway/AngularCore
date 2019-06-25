using System;
using DataAccess.Models;

namespace BusinessLogic.Validation.ModelValidation.Validators
{
    public class BlogValidator : ModelValidator<Blog>
    {
        // ReSharper disable once ConvertToConstant.Local
        private static readonly string ValidationPrefix = nameof(Blog);
        
        public override bool ValidateCreate(Blog model)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUpdate(Blog model)
        {
            return FinalizeValidation();
        }

        public override bool ValidateDelete(Blog model)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(Blog model)
        {
            throw new NotImplementedException();
        }
    }
}