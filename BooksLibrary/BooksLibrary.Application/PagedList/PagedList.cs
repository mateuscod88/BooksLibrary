namespace BooksLibrary.Application.PagedList;

public abstract class PagedList<T>
{
    public int CurrentPage { get; init; }
    public int PageSize { get; init; }
    public int TotalPages { get; init; }
    public int TotalCount { get; init; }
    public IEnumerable<T> Items { get; init; } = [];
}