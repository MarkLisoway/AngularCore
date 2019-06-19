using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq.Expressions;
using BusinessLogic.Validation.PropertyValidation;

namespace BusinessLogic.Validation.ModelValidation
{
    public abstract class ModelValidatorBase<TModel> : IModelValidator<TModel>
    {
        protected readonly ICollection<IPropertyValidationError> Errors;
        private bool _hasValidationBeenRun;

        protected ModelValidatorBase()
        {
            Errors = new List<IPropertyValidationError>();
            _hasValidationBeenRun = false;
        }

        public bool ValidateCreate(object model)
        {
            if (model is TModel modelT) return ValidateCreate(modelT);

            return FinalizeValidation(false);
        }

        public bool ValidateUpdate(object model, params Expression<Func<object, object>>[] updatedProperties)
        {
            var doesUpdatedPropertiesRepresentModel = updatedProperties is Expression<Func<TModel, object>>[];
            if (!doesUpdatedPropertiesRepresentModel)
            {
                throw new InvalidCastException($"Given updated properties do not represent the type {nameof(TModel)}");
            }
            var castedUpdatedProperties = updatedProperties as Expression<Func<TModel, object>>[];
            
            if (model is TModel modelT) return ValidateUpdate(modelT, castedUpdatedProperties);

            return FinalizeValidation(false);
        }

        public bool ValidateDelete(object model)
        {
            if (model is TModel modelT) return ValidateDelete(modelT);

            return FinalizeValidation(false);
        }

        public bool Validate(object model)
        {
            if (model is TModel modelT) return Validate(modelT);

            return FinalizeValidation(false);
        }

        public abstract bool ValidateCreate(TModel model);

        public abstract bool ValidateUpdate(TModel model, params Expression<Func<TModel, object>>[] updatedProperties);

        public abstract bool ValidateDelete(TModel model);

        public abstract bool Validate(TModel model);

        public IReadOnlyList<IPropertyValidationError> GetErrors()
        {
            if (!_hasValidationBeenRun)
                throw new InvalidOperationException("Must validate before attempting to get any errors.");
            return Errors.ToImmutableList();
        }

        protected bool FinalizeValidation(bool isModelValid)
        {
            _hasValidationBeenRun = true;
            return isModelValid;
        }

        protected bool FinalizeValidation()
        {
            return FinalizeValidation(Errors.Count <= 0);
        }
    }
}