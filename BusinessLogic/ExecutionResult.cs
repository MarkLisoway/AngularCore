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

        public bool WasSuccess { get; internal set; }


        internal static ExecutionResult<TResult> Success(TResult results)
        {
            return new ExecutionResult<TResult>
            {
                Results = results,
                WasSuccess = true
            };
        }


        internal static ExecutionResult<TResult> Fail(
            IReadOnlyList<IPropertyValidationError> errors)
        {
            return new ExecutionResult<TResult>
            {
                Errors = errors,
                WasSuccess = false
            };
        }
    }
}