using System.Collections.Generic;
using BusinessLogic.Validation.PropertyValidation;

namespace BusinessLogic
{
    public sealed class ExecutionResult<TResult>
    {
        internal ExecutionResult()
        {
            Errors = new List<IPropertyValidationError>();
        }

        public TResult Results { get; internal set; }

        public IReadOnlyList<IPropertyValidationError> Errors { get; internal set; }

        public bool Success { get; internal set; }
    }
}