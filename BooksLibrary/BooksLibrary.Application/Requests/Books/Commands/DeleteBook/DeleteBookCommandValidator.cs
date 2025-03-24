using BooksLibrary.Application.Validation.Books;
using FluentValidation;

namespace BooksLibrary.Application.Requests.Books.Commands.DeleteBook;

internal sealed class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}