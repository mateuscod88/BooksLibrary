using AutoMapper;
using AutoMapper.QueryableExtensions;
using BooksLibrary.Application.PagedList;
using BooksLibrary.Application.Shared.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Requests.Books.Queries.GetBooks;

internal sealed class GetBooksQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    : IRequestHandler<GetBooksQuery, GetBooksResponse>
{
    public async Task<GetBooksResponse> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    =>  await appDbContext.Books
                .AsNoTracking()
                .ApplySort(request.SortOrder, request.OrderBy)
                .ProjectTo<BookDto>(mapper.ConfigurationProvider)
                .ToPagedListAsync<GetBooksResponse,BookDto>(request.PageNumber,request.PageSize, cancellationToken);
    
}