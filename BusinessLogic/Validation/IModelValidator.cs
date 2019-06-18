using System.Collections.Generic;

namespace BusinessLogic.Validation
{
    /// <summary>
    ///     Validation interface for any object before the object's request gets
    ///     passed to the data layer.
    /// </summary>
    public interface IModelValidator
    {
        /// <summary>
        ///     Validates an object for a create operation.
        /// </summary>
        /// <param name="model">Object to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool ValidateCreate(object model);


        /// <summary>
        ///     Validates an object for an update operation.
        /// </summary>
        /// <param name="model">Object to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool ValidateUpdate(object model);


        /// <summary>
        ///     Validates an object for a delete operation.
        /// </summary>
        /// <param name="model">Object to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool ValidateDelete(object model);


        /// <summary>
        ///     Base validation method. Usually used for generic validation.
        /// </summary>
        /// <param name="model">Object to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool Validate(object model);


        /// <summary>
        ///     Gets an <see cref="IReadOnlyList{T}" /> of any errors that were found.
        /// </summary>
        /// <returns>Any errors that were found.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when called before <see cref="Validate" />.</exception>
        IReadOnlyList<IValidationError> GetErrors();
    }

    /// <summary>
    ///     Validation interface for all models before they get passed to the data access layer.
    /// </summary>
    /// <typeparam name="TModel">Type of Database model being validated.</typeparam>
    public interface IModelValidator<in TModel> : IModelValidator
    {
        /// <summary>
        ///     Validates the given domain model for a create operation.
        /// </summary>
        /// <param name="model">Model to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool ValidateCreate(TModel model);


        /// <summary>
        ///     Validates the given domain model for an update operation.
        /// </summary>
        /// <param name="model">Model to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool ValidateUpdate(TModel model);


        /// <summary>
        ///     Validates the given domain model for a delete operation.
        /// </summary>
        /// <param name="model">Model to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool ValidateDelete(TModel model);


        /// <summary>
        ///     Validates the given domain model.
        /// </summary>
        /// <param name="model">Model to validate.</param>
        /// <returns><code>true</code> if valid, or <code>false</code> otherwise.</returns>
        bool Validate(TModel model);
    }
}