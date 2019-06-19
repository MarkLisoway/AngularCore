using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic.Validation.ModelValidation
{
    internal static class ModelValidationExtensions
    {
        internal static ISet<string> GetSquashedUpdatePropertySet<TModel>(
            this Expression<Func<TModel, object>>[] updatedProperties)
        {
            var propertySet = new HashSet<string>();
            
            foreach (var updatedProperty in updatedProperties)
            {
                foreach (var updatedPropertyParameter in updatedProperty.Parameters)
                {
                    var test = updatedPropertyParameter.Name;
                }
            }

            return propertySet;
        }
    }
}