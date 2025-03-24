using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.PagedList;

public static class QueryableExtensions
{
    public static async Task<TPagedList> ToPagedListAsync<TPagedList,TElement>(this IQueryable<TElement> query, 
        int page, int pageSize, CancellationToken cancellationToken) where TPagedList : PagedList<TElement>, new()
    {
        var rowCount = await query.CountAsync(cancellationToken);
        var pageCount = (double)rowCount / pageSize;
        var skip = (page - 1) * pageSize;     
        var result = await query.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);
        return new TPagedList
        {
            Items = result,
            CurrentPage = page,
            PageSize = pageSize,
            TotalCount = rowCount,
            TotalPages = (int)Math.Ceiling(pageCount)
        };
    }
}