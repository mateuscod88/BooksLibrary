using AutoMapper;
using BooksLibrary.Application.Shared.Abstractions;
using BooksLibrary.Domain.Models;
using MediatR;

namespace BooksLibrary.Application.Requests.Books.Commands.CreateBook;

internal class CreateBookCommandHandler(IAppDbContext appDbContext, IMapper mapper)
    : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = mapper.Map<Book>(request);

        await appDbContext.Books.AddAsync(book, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}