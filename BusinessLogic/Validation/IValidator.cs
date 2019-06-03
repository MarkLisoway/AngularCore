using System.Collections.Generic;

namespace BusinessLogic.Validation
{
    public interface IValidator
    {
        bool Validate(object model);
        
        IReadOnlyList<IValidationError> GetErrors();
    }
    
    /// <summary>
    ///     Validation interface for all models before they get passed to the data access layer.
    /// </summary>
    /// <typeparam name="TModel">Type of Database model being validated.</typeparam>
    public interface IValidator<in TModel> : IValidator
    {
        /// <summary>
        ///     Validates the given domain model.
        /// </summary>
        /// <param name="model">Model to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool Validate(TModel model);

        /// <summary>
        ///     Gets a <see cref="IReadOnlyList{T}" /> of any errors that were found.
        /// </summary>
        /// <returns>Any errors that were found.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when called before <see cref="Validate" />.</exception>
        IReadOnlyList<IValidationError> GetErrors();
    }
}