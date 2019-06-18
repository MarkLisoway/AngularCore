namespace BusinessLogic.Validation
{
    public interface IValidationError
    {
        string PropertyIdentifier { get; }

        string Error { get; }
    }
}