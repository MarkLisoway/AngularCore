using System;
using System.Collections.Generic;

namespace BusinessLogic.Validation.PropertyValidation
{
    internal static class PropertyValidationExtensions
    {
        internal static PropertyValidations<T> BeginValidation<T>(this T property,
            string prefix,
            string alias,
            ICollection<IValidationError> errors)
        {
            return new PropertyValidations<T>(property, prefix, alias, errors);
        }


        //**************************************************
        //* Object validations
        //**************************************************


        internal static PropertyValidations<T> CannotBeNull<T>(this PropertyValidations<T> validator)
        {
            if (validator.Property == null) validator.AddError($"{validator.Alias} cannot be null");

            return validator;
        }


        internal static PropertyValidations<T> MustBeNull<T>(this PropertyValidations<T> validator)
        {
            if (validator.Property != null) validator.AddError($"{validator.Alias} must be null");

            return validator;
        }


        internal static PropertyValidations<T> CannotBeDefault<T>(this PropertyValidations<T> validator)
        {
            if (validator.Property.Equals(default(T))) validator.AddError($"{validator.Alias} cannot be default");

            return validator;
        }


        internal static PropertyValidations<T> MustBeDefault<T>(this PropertyValidations<T> validator)
        {
            if (!validator.Property.Equals(default(T))) validator.AddError($"{validator.Alias} must be default");

            return validator;
        }


        internal static PropertyValidations<T> CannotEqual<T>(this PropertyValidations<T> validator,
            T objectToCompare,
            string objectToCompareAlias = null)
        {
            if (validator.Property.Equals(objectToCompare))
            {
                objectToCompareAlias = objectToCompareAlias ?? nameof(objectToCompare);
                validator.AddError($"{validator.Alias} cannot equal {objectToCompareAlias}");
            }

            return validator;
        }


        internal static PropertyValidations<T> MustEqual<T>(this PropertyValidations<T> validator,
            T objectToCompare,
            string objectToCompareAlias = null)
        {
            if (!validator.Property.Equals(objectToCompare))
            {
                objectToCompareAlias = objectToCompareAlias ?? nameof(objectToCompare);
                validator.AddError($"{validator.Alias} must equal {objectToCompareAlias}");
            }

            return validator;
        }


        internal static PropertyValidations<T> IfThen<T>(
            this PropertyValidations<T> validator,
            bool condition,
            Func<PropertyValidations<T>, PropertyValidations<T>> doIfTrue)
        {
            if (condition) doIfTrue.Invoke(validator);

            return validator;
        }


        //**************************************************
        //* Integer validations
        //**************************************************


        internal static PropertyValidations<int> MustBeGreaterThan(this PropertyValidations<int> validator,
            int threshold)
        {
            if (!(validator.Property > threshold))
                validator.AddError($"{validator.Alias} must be greater than {threshold}");

            return validator;
        }


        internal static PropertyValidations<int> MustBeLessThan(this PropertyValidations<int> validator, int threshold)
        {
            if (!(validator.Property < threshold))
                validator.AddError($"{validator.Alias} must be less than {threshold}");

            return validator;
        }


        internal static PropertyValidations<int> MustBeGreaterThanOrEqualTo(this PropertyValidations<int> validator,
            int threshold)
        {
            if (validator.Property < threshold)
                validator.AddError($"{validator.Alias} must be greater than or equal to {threshold}");

            return validator;
        }


        internal static PropertyValidations<int> MustBeLessThanOrEqualTo(this PropertyValidations<int> validator,
            int threshold)
        {
            if (validator.Property > threshold)
                validator.AddError($"{validator.Alias} must be less than or equal to {threshold}");

            return validator;
        }


        //**************************************************
        //* String validations
        //**************************************************


        internal static PropertyValidations<string> CannotBeEmpty(this PropertyValidations<string> validator)
        {
            if (validator.Property == string.Empty) validator.AddError($"{validator.Alias} cannot be empty");

            return validator;
        }


        internal static PropertyValidations<string> MustBeEmpty(this PropertyValidations<string> validator)
        {
            if (validator.Property != string.Empty) validator.AddError($"{validator.Alias} must be empty");

            return validator;
        }
    }
}