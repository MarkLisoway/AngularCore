namespace BusinessLogic.Validation
{
    public interface IValidationError
    {
        string PropertyName { get; }
        string Error { get; }
    }
}