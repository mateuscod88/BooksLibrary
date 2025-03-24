using BooksLibrary.Application.Behaviour;
using BooksLibrary.Domain.Policies;
using BooksLibrary.Domain.Policies.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibrary.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddScoped<IBookPolicy,BookPolicy>();

        return services;
    }
    
}