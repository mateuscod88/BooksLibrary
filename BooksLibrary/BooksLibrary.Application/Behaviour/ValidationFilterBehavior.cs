using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using BooksLibrary.Application.Behaviour.Exceptions;
using BooksLibrary.Application.Behaviour.Exceptions.ErrorCode;

namespace BooksLibrary.Application.Behaviour;

public class ValidationFilterBehavior : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationFilterBehavior(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var parameters = context.ActionArguments;

        foreach (var parameter in parameters)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(parameter.Value.GetType());
            var validator = _serviceProvider.GetService(validatorType) as IValidator;

            if (validator != null)
            {
                var validationContext = new ValidationContext<object>(parameter.Value);
                var validationResult = await validator.ValidateAsync(validationContext);
                if (!validationResult.IsValid)
                {
                    var errorsDictionary = validationResult
                        .Errors
                        .Where(x => x is not null)
                        .GroupBy(
                            x => x.PropertyName,
                            x => x.ErrorMessage,
                            (propertyName, errorMessages) => new
                            {
                                Key = propertyName,
                                Value = errorMessages
                            })
                        .ToDictionary(x => x.Key, x => x.Value.ToArray());
                    throw new VerificationException("One or more validation failed.", ErrorCodes.ValidationFailed,
                        errorsDictionary);
                }
            }
        }

        await next();
    }
}