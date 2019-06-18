using System.Collections.Generic;
using BusinessLogic.Validation;

namespace BusinessLogic
{
    public sealed class ExecutionResult<TResult>
    {
        internal ExecutionResult()
        {
            Errors = new List<IValidationError>();
        }

        public TResult Results { get; internal set; }

        public IReadOnlyList<IValidationError> Errors { get; internal set; }

        public bool Success { get; internal set; }
    }
}