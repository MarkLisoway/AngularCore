namespace BusinessLogic.Validation
{
    public class ValidationError : IValidationError
    {
        internal ValidationError(string alias, string error)
        {
            PropertyName = alias;
            Error = error;
        }

        public string PropertyName { get; }
        public string Error { get; }
    }
}