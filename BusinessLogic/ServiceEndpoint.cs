using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogic.Validation;
using DataAccess.Context;

namespace BusinessLogic
{
    public sealed class ServiceEndpoint
    {
        private readonly AngularCoreContext _context;

        public ServiceEndpoint(AngularCoreContext context)
        {
            _context = context;
        }

        public ExecutionResult<TModel> ExecuteCreate<TModel>(TModel model)
            where TModel : class
        {
            var validator = GetValidator<TModel>();
            var isValid = validator.ValidateCreate(model);

            if (!isValid) return CreateFailedExecutionResult<TModel>(validator.GetErrors());

            var result = _context.Set<TModel>().Add(model);
            return CreateSuccessfulExecutionResult(result.Entity);
        }
        
        public ExecutionResult<IQueryable<TDto>> ExecuteRead<TModel, TDto>(Expression<Func<TModel, TDto>> selector)
            where TModel : class
        {
            var results = _context.Set<TModel>().Select(selector);
            return CreateSuccessfulExecutionResult(results);
        }

        public ExecutionResult<TModel> ExecuteUpdate<TModel>(TModel model)
            where TModel : class
        {
            var validator = GetValidator<TModel>();
            var isValid = validator.ValidateUpdate(model);

            if (!isValid) return CreateFailedExecutionResult<TModel>(validator.GetErrors());

            var result = _context.Set<TModel>().Update(model);
            return CreateSuccessfulExecutionResult(result.Entity);
        }

        public ExecutionResult<TModel> ExecuteDelete<TModel>(TModel model)
            where TModel : class
        {
            var validator = GetValidator<TModel>();
            var isValid = validator.ValidateDelete(model);

            if (!isValid) return CreateFailedExecutionResult<TModel>(validator.GetErrors());

            var result = _context.Set<TModel>().Remove(model);
            return CreateSuccessfulExecutionResult(result.Entity);
        }

        private static IModelValidator GetValidator<TModel>()
        {
            var validatorFactory = ValidationMappings.Mappings[typeof(TModel)];
            if (validatorFactory == null) throw new Exception("Must have registered validation mapping.");

            var validator = validatorFactory.Invoke();
            return validator;
        }

        private static ExecutionResult<TResult> CreateSuccessfulExecutionResult<TResult>(TResult results)
        {
            return new ExecutionResult<TResult>
            {
                Results = results,
                Success = true
            };
        }

        private static ExecutionResult<TResult> CreateFailedExecutionResult<TResult>(
            IReadOnlyList<IValidationError> errors)
        {
            return new ExecutionResult<TResult>
            {
                Errors = errors,
                Success = false
            };
        }
    }
}