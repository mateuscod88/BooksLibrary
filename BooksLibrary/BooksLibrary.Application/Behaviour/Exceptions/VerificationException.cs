using BooksLibrary.Application.Behaviour.Exceptions.ErrorCode;

namespace BooksLibrary.Application.Behaviour.Exceptions;

public class VerificationException : BaseApplicationException
{
    public IDictionary<string, string[]> ValidationErrors { get; } =
        new Dictionary<string, string[]>();
    public VerificationException() : this("Cannot process entity", ErrorCodes.ValidationFailed) { }

    public VerificationException(Type entityType) : this($"Cannot process {entityType.Name}",
        ErrorCodes.ValidationFailed) { }

    public VerificationException(Type entityType, string id) : this(
        $"Cannot process entity {entityType.Name} with id {id}", ErrorCodes.ValidationFailed) { }

    public VerificationException(string message, Exception innerException) : base(message,
        ErrorCodes.ValidationFailed, innerException) { }

    public VerificationException(string message) : base(message, ErrorCodes.ValidationFailed) { }
    public VerificationException(string message, string errorCode) : base(message, errorCode) { }

    public VerificationException(string message, string errorCode,
        IDictionary<string, string[]> validationErrors) : base(message, errorCode)
    {
        ValidationErrors = validationErrors;
    }
}