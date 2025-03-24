using BooksLibrary.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.Application.Requests.Books.Commands.DeleteBook;

public sealed class DeleteBookCommand : IRequest<Unit>
{
    public required int Id{ get; init; }
}