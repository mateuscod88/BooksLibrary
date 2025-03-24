using BooksLibrary.Domain.Enums;
using MediatR;

namespace BooksLibrary.Application.Requests.Books.Commands.CreateBook;

public sealed class CreateBookCommand : IRequest<int>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public BookStatus Status { get; set; }
}