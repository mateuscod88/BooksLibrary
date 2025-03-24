using BooksLibrary.Application.Behaviour;
using BooksLibrary.Application.Shared.Abstractions;
using BooksLibrary.Domain.Enums;
using BooksLibrary.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Requests.Books.Commands.DeleteBook;

internal class DeleteBookCommandHandler(IAppDbContext appDbContext)
    : IRequestHandler<DeleteBookCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await appDbContext.Books.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken)
                   ?? throw new NotFoundException(typeof(Book), request.Id.ToString());
        appDbContext.Books.Remove(book);
        await appDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}