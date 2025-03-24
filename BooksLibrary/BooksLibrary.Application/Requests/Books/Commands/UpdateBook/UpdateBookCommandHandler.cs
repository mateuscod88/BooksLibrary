using AutoMapper;
using BooksLibrary.Application.Behaviour;
using BooksLibrary.Application.Shared.Abstractions;
using BooksLibrary.Domain.Models;
using BooksLibrary.Domain.Policies.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Requests.Books.Commands.UpdateBook;

public sealed class UpdateBookCommandHandler(IBookPolicy bookPolicy, IAppDbContext appDbContext)
    : IRequestHandler<UpdateBookCommand, Unit>
{
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await appDbContext.Books.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken) ??
                   throw new NotFoundException(typeof(Book), request.Id.ToString());

        book.Title = request.Title;
        book.Author = request.Author;
        book.Isbn = request.Isbn;

        if (bookPolicy.CanChangeStatus(book.Status, request.Status))
        {
            book.Status = request.Status;
        }

        await appDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}