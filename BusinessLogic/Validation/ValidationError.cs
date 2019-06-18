namespace BusinessLogic.Validation
{
    public class ValidationError : IValidationError
    {
        internal ValidationError(string identifier, string error)
        {
            PropertyIdentifier = identifier;
            Error = error;
        }

        public string PropertyIdentifier { get; }

        public string Error { get; }
    }
}