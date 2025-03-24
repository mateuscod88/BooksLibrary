using BooksLibrary.Application.Behaviour.Exceptions;
using BooksLibrary.Application.Behaviour.Exceptions.ErrorCode;

namespace BooksLibrary.Application.Behaviour;

public class NotFoundException : BaseApplicationException {
    public NotFoundException() : this("Entity not found", ErrorCodes.NotFound) { }
    public NotFoundException(Type entityType) : this($"{entityType.Name} not found", ErrorCodes.NotFound) { }

    public NotFoundException(Type entityType, string id) : this($"{entityType.Name} not found with id {id}",
        ErrorCodes.NotFound) { }

    public NotFoundException(string message, Exception innerException) : base(message, ErrorCodes.NotFound,
        innerException) { }

    public NotFoundException(string message) : base(message, ErrorCodes.NotFound) { }
    public NotFoundException(string message, string errorCode) : base(message, errorCode) { }
}