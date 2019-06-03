using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogic.Validation;
using DataAccess.Context;

namespace BusinessLogic
{
    public class ServiceEndpoint
    {
        public IReadOnlyList<IValidationError> ExecuteRequestIfValid<TModel, TDto>(TModel model,
            Expression<Func<TModel, TDto>> expression)
            where TModel : class
        {
            var validatorFactory = ValidationMappings.Mappings[typeof(TModel)];
            if (validatorFactory == null)
            {
                return null;
            }

            var validator = validatorFactory.Invoke();
            var isValid = validator.Validate(model);
            if (!isValid) return validator.GetErrors();
            
            // TODO Execute EFCore expression here.
            using (var context = new AngularCoreContext())
            {
                return context.Set<TModel>().Select(expression);
            }

        }
    }
}