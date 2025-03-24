using BooksLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Shared.Abstractions;

public interface IAppDbContext
{
    DbSet<Book> Books { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}