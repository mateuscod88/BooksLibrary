using BooksLibrary.Application.Validation.Books;
using FluentValidation;

namespace BooksLibrary.Application.Requests.Books.Commands.CreateBook;

internal sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Author).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Isbn).IsbnValidation();
    }
}