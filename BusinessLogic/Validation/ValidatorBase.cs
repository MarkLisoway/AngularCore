using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BusinessLogic.Validation
{
    public abstract class ValidatorBase<TModel> : IValidator<TModel>
    {
        protected readonly ICollection<IValidationError> Errors;
        protected bool HasValidationBeenRun = false;

        protected ValidatorBase()
        {
            Errors = new List<IValidationError>();
        }

        public abstract bool Validate(TModel model);

        public bool Validate(object model)
        {
            if (model is TModel modelT) return Validate(modelT);

            return FinalizeValidation(false);
        }

        public virtual IReadOnlyList<IValidationError> GetErrors()
        {
            if (!HasValidationBeenRun)
                throw new InvalidOperationException("Must call Validate before attempting to get any errors.");
            return Errors.ToImmutableList();
        }

        protected bool FinalizeValidation(bool isModelValid)
        {
            HasValidationBeenRun = true;
            return isModelValid;
        }

        protected bool FinalizeValidation()
        {
            return FinalizeValidation(Errors.Count <= 0);
        }
    }
}