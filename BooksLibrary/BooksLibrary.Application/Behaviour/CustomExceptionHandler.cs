using System.Text.Json;
using System.Text.Json.Serialization;
using BooksLibrary.Application.Behaviour.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.Application.Behaviour;

internal sealed class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            VerificationException verificationException => new ValidationProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "An error oc3curred",
                Type = verificationException.GetType().Name,
                Detail = verificationException.Message,
                Errors = verificationException.ValidationErrors
            },
            NotFoundException => new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = "An error occurred",
                Type = exception.GetType().Name,
                Detail = exception.Message,
            },
            _ => new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred",
                Type = exception.GetType().Name,
                Detail = exception.Message,
            },
        };
        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails,JsonSerializerOptions.Default, cancellationToken);

        return true;
    }
}