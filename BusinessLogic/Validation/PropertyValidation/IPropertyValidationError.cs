namespace BusinessLogic.Validation.PropertyValidation
{
    public interface IPropertyValidationError
    {
        string PropertyIdentifier { get; }

        string Error { get; }
    }
}