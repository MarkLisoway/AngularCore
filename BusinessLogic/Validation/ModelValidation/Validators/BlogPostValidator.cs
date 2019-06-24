using System;
using System.Linq.Expressions;
using BusinessLogic.ValidationModels;
using DataAccess.Models;

namespace BusinessLogic.Validation.ModelValidation.Validators
{
    public class BlogPostValidator : ModelValidator<ValidationBlogPost>
    {
        public override bool ValidateCreate(ValidationBlogPost model)
        {
            return FinalizeValidation();
        }

        public override bool ValidateUpdate(ValidationBlogPost model)
        {
            return FinalizeValidation();
        }

        public override bool ValidateDelete(ValidationBlogPost model)
        {
            return FinalizeValidation();
        }

        public override bool Validate(ValidationBlogPost model)
        {
            return FinalizeValidation();
        }
    }
}