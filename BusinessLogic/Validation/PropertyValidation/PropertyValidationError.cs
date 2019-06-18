namespace BusinessLogic.Validation.PropertyValidation
{
    public class PropertyValidationError : IPropertyValidationError
    {
        internal PropertyValidationError(string identifier, string error)
        {
            PropertyIdentifier = identifier;
            Error = error;
        }

        public string PropertyIdentifier { get; }

        public string Error { get; }
    }
}