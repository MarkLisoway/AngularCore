using System.Collections.Generic;

namespace BusinessLogic.Validation
{
    internal static class ValidationExtensions
    {
        public static StringValidations StartValidations(this string stringProperty,
            ICollection<IValidationError> errors,
            string alias) => new StringValidations(stringProperty, errors, alias);
    }

    internal abstract class ValidationBase<TValue>
    {
        protected readonly TValue Alias;
        protected readonly ICollection<IValidationError> Errors;
        protected readonly TValue Value;

        internal ValidationBase(TValue value, ICollection<IValidationError> errors, TValue alias)
        {
            Value = value;
            Errors = errors;
            Alias = alias;
        }
    }

    internal class StringValidations : ValidationBase<string>
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
}