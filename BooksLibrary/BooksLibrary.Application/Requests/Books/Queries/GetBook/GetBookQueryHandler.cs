using AutoMapper;
using AutoMapper.QueryableExtensions;
using BooksLibrary.Application.Behaviour;
using BooksLibrary.Application.Shared.Abstractions;
using BooksLibrary.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Requests.Books.Queries.GetBook;

internal sealed class GetBookQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    : IRequestHandler<GetBookQuery, GetBookResponse>
{
    public async Task<GetBookResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        return  await appDbContext.Books
            .Where(b => b.Id == request.BookId)
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .Select(dto => new GetBookResponse(dto))
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(typeof(Book), request.BookId.ToString());
        
    }
}