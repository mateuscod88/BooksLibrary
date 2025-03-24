using MediatR;

namespace BooksLibrary.Application.Requests.Books.Queries.GetBook;

public sealed class GetBookQuery : IRequest<GetBookResponse>
{
    public int BookId { get; set; }
}