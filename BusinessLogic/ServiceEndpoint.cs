using System;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogic.Validation.ModelValidation;
using BusinessLogic.ValidationModels;
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
            var validator = ModelValidationMappings.GetValidationMapping<TModel>();
            var isValid = validator.ValidateCreate(model);

            if (!isValid) return ExecutionResult<TModel>.Fail(validator.GetErrors());

            var result = _context.Set<TModel>().Add(model);
            return ExecutionResult<TModel>.Success(result.Entity);
        }

        public ExecutionResult<IQueryable<TDto>> ExecuteRead<TModel, TDto>(Expression<Func<TModel, TDto>> selector)
            where TModel : class
        {
            var results = _context.Set<TModel>().Select(selector);
            return ExecutionResult<IQueryable<TDto>>.Success(results);
        }


        public ExecutionResult<TValidationModel> ExecuteUpdate<TValidationModel, TModel>(TValidationModel validationModel)
        where TValidationModel : IValidationModel<TModel>
        {
            var validator = ModelValidationMappings.GetValidationMapping<TValidationModel>();
            var isValid = validator.ValidateUpdate(validationModel);

            if (!isValid) return ExecutionResult<TValidationModel>.Fail(validator.GetErrors());

            var model = validationModel.ToModel();
            _context.Attach(model);
            var entry = _context.Entry(model);
            
            entry.ApplyModificationFlags(updatedProperties);

            return ExecutionResult<TValidationModel>.Success(entry.Entity);
        }


        public ExecutionResult<TModel> ExecuteDelete<TModel>(TModel model)
            where TModel : class
        {
            var validator = ModelValidationMappings.GetValidationMapping<TModel>();
            var isValid = validator.ValidateDelete(model);

            if (!isValid) return ExecutionResult<TModel>.Fail(validator.GetErrors());

            var result = _context.Set<TModel>().Remove(model);
            return ExecutionResult<TModel>.Success(result.Entity);
        }
    }
}