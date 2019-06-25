using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using BusinessLogic.Validation.PropertyValidation;

namespace BusinessLogic.Validation.ModelValidation
{

    public abstract class ModelValidator<TValidationModel> : IModelValidator<TValidationModel>
    {

        protected readonly ICollection<IPropertyValidationError> Errors;

        private bool _hasValidationBeenRun;

        protected ModelValidator()
        {
            Errors = new List<IPropertyValidationError>();
            _hasValidationBeenRun = false;
        }

        public bool ValidateCreate(object model)
        {
            if (model is TValidationModel modelT) return ValidateCreate(modelT);

            return FinalizeValidation(false);
        }

        public bool ValidateUpdate(object model)
        {
            if (model is TValidationModel modelT) return ValidateUpdate(modelT);

            return FinalizeValidation(false);
        }

        public bool ValidateDelete(object model)
        {
            if (model is TValidationModel modelT) return ValidateDelete(modelT);

            return FinalizeValidation(false);
        }

        public bool Validate(object model)
        {
            if (model is TValidationModel modelT) return Validate(modelT);

            return FinalizeValidation(false);
        }

        public abstract bool ValidateCreate(TValidationModel model);

        public abstract bool ValidateUpdate(TValidationModel model);

        public abstract bool ValidateDelete(TValidationModel model);

        public abstract bool Validate(TValidationModel model);

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
