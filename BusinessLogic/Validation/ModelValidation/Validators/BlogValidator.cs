using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLogic.Validation.PropertyValidation;
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

        public override bool ValidateUpdate(Blog model, params Expression<Func<Blog, object>>[] updatedProperties)
        {
            model.Posts.BeginValidation(ValidationPrefix, nameof(model.Posts), Errors)
                .IfThen(!string.IsNullOrEmpty(model.Name), posts => posts
                    .CannotBeNull())
                .ValidateEnumerable(validationInfo =>
                {
                    var enumerationModel = validationInfo.Model;
                    enumerationModel.Id.BeginValidation(validationInfo.Prefix, nameof(enumerationModel.Id), Errors)
                        .IfThen(enumerationModel.Id < 1, id => id
                            .MustBeDefault());
                });
            
            model.Posts.BeginValidation(ValidationPrefix, nameof(model.Posts), Errors)
                

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