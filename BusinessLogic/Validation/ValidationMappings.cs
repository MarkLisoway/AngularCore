using System;
using System.Collections.Generic;
using BusinessLogic.Validation.Validators;

namespace BusinessLogic.Validation
{
    internal static class ValidationMappings
    {
        internal static readonly ValidationDictionary Mappings = new ValidationMappingsBuilder()
            .RegisterValidation(() => new UserModelValidator())
            .Build();

        private class ValidationMappingsBuilder
        {
            private bool _built;
            private readonly ValidationDictionary _validators = new ValidationDictionary();

            internal ValidationMappingsBuilder RegisterValidation<TModel>(Func<IModelValidator<TModel>> factory)
            {
                if (_built)
                    throw new InvalidOperationException(
                        $"{nameof(ValidationMappingsBuilder)} cannot register validations after build.");

                _validators[typeof(TModel)] = factory;
                
                return this;
            }

            internal ValidationDictionary Build()
            {
                _built = true;
                return _validators;
            }
        }

        internal sealed class ValidationDictionary : Dictionary<Type, Func<IModelValidator>>
        {
            
        }
    }
}