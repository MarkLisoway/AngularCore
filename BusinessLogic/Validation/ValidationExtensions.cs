using System.Collections.Generic;

namespace BusinessLogic.Validation
{
    internal static class ValidationExtensions
    {
        public static StringValidations StartValidations(this string stringProperty,
            ICollection<IValidationError> errors,
            string alias) => new StringValidations(stringProperty, errors, alias);
        
        public static IntegerValidations StartValidations(this int intProperty,
            ICollection<IValidationError> errors,
            string alias) => new IntegerValidations(intProperty, errors, alias);
    }

    internal abstract class ValidationBase<TValue>
    {
        protected readonly string Alias;
        protected readonly ICollection<IValidationError> Errors;
        protected readonly TValue Value;

        internal ValidationBase(TValue value, ICollection<IValidationError> errors, string alias)
        {
            Value = value;
            Errors = errors;
            Alias = alias;
        }
    }

    internal class ObjectValidations<TValidations, TValue> : ValidationBase<TValue>
    where TValidations : class
    {
        internal ObjectValidations(TValue value, ICollection<IValidationError> errors, string alias)
            : base(value, errors, alias)
        {
        }

        internal TValidations CannotBeNull()
        {
            if (Value == null)
                Errors.Add(new ValidationError(Alias, $"{Alias} cannot be null."));
            return this as TValidations;
        }
        
        internal TValidations MustBeNull()
        {
            if (Value != null)
                Errors.Add(new ValidationError(Alias, $"{Alias} must be null."));
            return this as TValidations;
        }
        
        internal TValidations MustBeDefault()
        {
            if (!Value.Equals(default(TValue)))
                Errors.Add(new ValidationError(Alias, $"{Alias} must be default value."));
            return this as TValidations;
        }
    }
    
    internal class StringValidations : ObjectValidations<StringValidations, string>
    {
        internal StringValidations(string value, ICollection<IValidationError> errors, string alias)
            : base(value, errors, alias)
        {
        }
        
        internal StringValidations CannotBeNullOrEmpty()
        {
            if (string.IsNullOrEmpty(Value))
                Errors.Add(new ValidationError(Alias, $"{Alias} cannot be null or empty."));
            return this;
        }
    }

    internal class IntegerValidations : ObjectValidations<IntegerValidations, int>
    {
        internal IntegerValidations(int value, ICollection<IValidationError> errors, string alias)
            : base(value, errors, alias)
        {
        }
        
        internal IntegerValidations MustBeGreaterThanOrEqualTo(int threshold)
        {
            if (!(Value >= threshold))
                Errors.Add(new ValidationError(Alias, $"{Alias} must be greater than or equal to {threshold}."));
            return this;
        }
        
        internal IntegerValidations MustBeLessThanOrEqualTo(int threshold)
        {
            if (!(Value <= threshold))
                Errors.Add(new ValidationError(Alias, $"{Alias} must be less than or equal to {threshold}."));
            return this;
        }
    }
}