using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BusinessLogic.Validation
{
    public abstract class ValidatorBase<TModel> : IValidator<TModel>
    {
        protected readonly ICollection<IValidationError> Errors;
        private bool _hasValidationBeenRun;

        protected ValidatorBase()
        {
            Errors = new List<IValidationError>();
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

        public IReadOnlyList<IValidationError> GetErrors()
        {
            if (!_hasValidationBeenRun)
                throw new InvalidOperationException("Must call Validate before attempting to get any errors.");
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