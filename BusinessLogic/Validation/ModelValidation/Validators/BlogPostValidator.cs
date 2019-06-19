using System;
using System.Linq.Expressions;
using DataAccess.Models;

namespace BusinessLogic.Validation.ModelValidation.Validators
{
    public class BlogPostValidator : ModelValidatorBase<BlogPost>
    {
        public override bool ValidateCreate(BlogPost model)
        {
            return FinalizeValidation();
        }

        public override bool ValidateUpdate(BlogPost model, params Expression<Func<BlogPost, object>>[] updatedProperties)
        {
            return FinalizeValidation();
        }

        public override bool ValidateDelete(BlogPost model)
        {
            return FinalizeValidation();
        }

        public override bool Validate(BlogPost model)
        {
            return FinalizeValidation();
        }
    }
}