using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public bool ValidateUpdate(object model)
        {
            if (model is TModel modelT) return ValidateUpdate(modelT);

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

        public abstract bool ValidateUpdate(TModel model);

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