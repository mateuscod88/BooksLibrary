using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace BooksLibrary.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        services.AddAutoMapper(Application.AssemblyHelper.GetExecutingAssembly());
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblyContaining<Application.AssemblyHelper>());

        services.AddValidatorsFromAssemblyContaining<Application.AssemblyHelper>(
            includeInternalTypes: true);
        return services;
    }
}