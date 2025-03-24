using BooksLibrary.Application.Shared.Abstractions;
using BooksLibrary.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibrary.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<IAppDbContext, AppDbContext>((options) =>
        {
            options.UseInMemoryDatabase("BooksLibrary");
        });
        return serviceCollection;
    }
}