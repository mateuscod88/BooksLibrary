using BooksLibrary.Application.PagedList;
using MediatR;

namespace BooksLibrary.Application.Requests.Books.Queries.GetBooks;

public class GetBooksQuery : IRequest<GetBooksResponse>
{
    public int PageSize { get; init; } = 20;
    public int PageNumber { get; init; } = 1;
    public SortOrder SortOrder { get; init; } = SortOrder.Descending;
    public BookSortColumn OrderBy { get; init; } = BookSortColumn.Author;
}