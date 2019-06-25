using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace BusinessLogic.Validation.ModelValidation
{

    internal static class ModelValidationExtensions
    {

        internal static ISet<string> GetSquashedUpdatePropertySet<TModel>(
            this IEnumerable<Expression<Func<TModel, object>>> updatedProperties)
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


        internal static PropertyInfo GetPropInfo<TSource, TProperty>(
            this TSource source,
            Expression<Func<TSource, TProperty>> propertySelector)
        {
            var type = typeof(TSource);

            if (!(propertySelector.Body is MemberExpression member))
            {
                throw new ArgumentException("Selector does not select a property. Could be referring to a method.");
            }

            if (!(member.Member is PropertyInfo propInfo))
            {
                throw new Exception("Selector refers to a field, not a property.");
            }

            var propReflectedType = propInfo.ReflectedType;

            if (propReflectedType == null)
            {
                throw new NullReferenceException(
                    $"{nameof(propertySelector)} does not have an encompassing class type.");
            }

            if (!propReflectedType.IsAssignableFrom(type))
            {
                throw new Exception($"{nameof(propertySelector)} refers to a property that is not from type {type}.");
            }

            return propInfo;
        }


        internal static bool IsACustomClassEnumerable<TSource, TProperty>(
            this Expression<Func<TSource, TProperty>> propertySelector)
        {
            var propertyType = typeof(TProperty);

            if (propertyType.IsPrimitive || propertyType == typeof(string))
            {
                return false;
            }

            var enumerableType = typeof(IEnumerable);

            if (!(propertySelector.Body is MemberExpression member))
            {
                return false;
            }

            if (!(member.Member is PropertyInfo propInfo))
            {
                return false;
            }

            var propReflectedType = propInfo.ReflectedType;

            return propReflectedType != null && propReflectedType.IsAssignableFrom(enumerableType);
        }

    }

}
