using System;
using System.Collections.Generic;
using BusinessLogic.Validation.ModelValidation.Validators;

namespace BusinessLogic.Validation.ModelValidation
{
    internal static class ModelValidationMappings
    {
        private static readonly ValidationDictionary Mappings = new ValidationMappingsRegistry()
            .RegisterValidation(() => new UserModelValidator())
            .RegisterValidation(() => new BlogPostValidator())
            .RegisterValidation(() => new BlogValidator())
            .CompleteRegistration();

        internal static IModelValidator<TModel> GetValidationMapping<TModel>()
        {
            var mapping = Mappings.GetMapping<TModel>();
            if (mapping == null)
            {
                throw new KeyNotFoundException("Validation mapping not found. Are you sure it has been registered?");   
            }

            if (!(mapping is Func<IModelValidator<TModel>>))
            {
                // This exception should never happen
                throw new InvalidCastException(
                    "Model mapped to factory validator that does not validate the given model.");
            }

            var factory = mapping as Func<IModelValidator<TModel>>;
            return factory.Invoke();
        }
        

        private sealed class ValidationMappingsRegistry
        {
            private readonly ValidationDictionary _validators = new ValidationDictionary();
            private bool _built;

            internal ValidationMappingsRegistry RegisterValidation<TModel>(Func<IModelValidator<TModel>> factory)
            {
                if (_built)
                    throw new InvalidOperationException(
                        $"{nameof(ValidationMappingsRegistry)} cannot register validations after build.");

                _validators.AddMapping(factory);

                return this;
            }

            internal ValidationDictionary CompleteRegistration()
            {
                _built = true;
                return _validators;
            }
        }

        private sealed class ValidationDictionary
        {
            private readonly IDictionary<Type, object> _mappings = new Dictionary<Type, object>();

            internal void AddMapping<TModel>(Func<IModelValidator<TModel>> factory)
            {
                _mappings[typeof(TModel)] = factory;
            }

            
            internal object GetMapping<TModel>()
            {
                return _mappings[typeof(TModel)];
            }
            
            
            internal object GetMapping(Type type)
            {
                return _mappings[type];
            }
        }
    }
}