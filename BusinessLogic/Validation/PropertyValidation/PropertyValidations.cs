using System.Collections.Generic;
using BusinessLogic.Validation.ModelValidation;

namespace BusinessLogic.Validation.PropertyValidation
{

    public sealed class PropertyValidations<T>
    {

        /// <summary>
        ///     Allows fluent validation for a specific property on a model.
        /// </summary>
        /// <param name="property">Property to validate.</param>
        /// <param name="prefix">
        ///     Parent prefix of the property. Combined with the alias to create a unique identifier for the
        ///     property.
        /// </param>
        /// <param name="alias">Alias of the property. Combined with the prefix to create a unique identifier for the property.</param>
        /// <param name="errors">Reference to a collection of errors in which the properties errors will be stored./></param>
        internal PropertyValidations(
            T property,
            string prefix,
            string alias,
            ICollection<IPropertyValidationError> errors)
        {
            Property = property;
            Alias = alias;
            Identifier = prefix + "." + alias;
            Errors = errors;
        }

        public T Property { get; }

        public string Alias { get; }

        public string Identifier { get; }

        /// <summary>
        ///     Reference to the <see cref="ICollection{T}" /> of errors in the <see cref="ModelValidator{TValidationModel}" />.
        /// </summary>
        private ICollection<IPropertyValidationError> Errors { get; }


        internal void AddError(string error)
        {
            Errors.Add(new PropertyValidationError(Identifier, error));
        }

    }



    internal sealed class EnumerablePropertyValidation<TModel>
    {


        internal EnumerablePropertyValidation(TModel model, string prefix)
        {
            Model = model;
            Prefix = prefix;
        }

        internal TModel Model { get; }

        internal string Prefix { get; }

    }

}
