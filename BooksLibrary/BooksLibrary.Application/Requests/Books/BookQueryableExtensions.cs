using System.Linq.Expressions;
using BooksLibrary.Application.PagedList;
using BooksLibrary.Application.Requests.Books.Queries.GetBooks;
using BooksLibrary.Domain.Models;

namespace BooksLibrary.Application.Requests.Books;

public static class BookQueryableExtensions
{
    public static IQueryable<Book> ApplySort(this IQueryable<Book> books, SortOrder sortOrder, BookSortColumn orderBy)
    {
        return sortOrder == SortOrder.Descending
            ? books.OrderByDescending(GetOrderBy(orderBy))
            : books.OrderBy(GetOrderBy(orderBy));
    }

    private static Expression<Func<Book, object>> GetOrderBy(BookSortColumn orderBy) => orderBy switch
    {
        BookSortColumn.Author => book => book.Author,
        BookSortColumn.Title => book => book.Title,
        BookSortColumn.Isbn => book => book.Isbn,
        _ => book => book.Title
    };
}