using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLogic.Validation.PropertyValidation;
using BusinessLogic.ValidationModels;
using DataAccess.Models;

namespace BusinessLogic.Validation.ModelValidation.Validators
{
    public class BlogValidator : ModelValidator<ValidationBlog>
    {
        // ReSharper disable once ConvertToConstant.Local
        private static readonly string ValidationPrefix = nameof(Blog);
        
        public override bool ValidateCreate(ValidationBlog model)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUpdate(ValidationBlog model)
        {
            return FinalizeValidation();
        }

        public override bool ValidateDelete(ValidationBlog model)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(ValidationBlog model)
        {
            throw new NotImplementedException();
        }
    }
}