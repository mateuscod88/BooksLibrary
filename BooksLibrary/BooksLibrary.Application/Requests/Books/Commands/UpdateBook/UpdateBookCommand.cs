using BooksLibrary.Domain.Enums;
using MediatR;

namespace BooksLibrary.Application.Requests.Books.Commands.UpdateBook;

public sealed class UpdateBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public BookStatus Status { get; set; }
}