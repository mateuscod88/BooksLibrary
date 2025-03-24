using BooksLibrary.Application.Requests.Books.Commands.CreateBook;
using BooksLibrary.Application.Requests.Books.Commands.DeleteBook;
using BooksLibrary.Application.Requests.Books.Commands.UpdateBook;
using BooksLibrary.Application.Requests.Books.Queries.GetBook;
using BooksLibrary.Application.Requests.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetBooksResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBooksAsync([FromQuery] GetBooksQuery request,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpGet("{id:int}", Name = nameof(GetBook))]
    [ProducesResponseType(typeof(GetBookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBook([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetBookQuery { BookId = id };
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> AddBook([FromBody] CreateBookCommand request, CancellationToken cancellationToken)
    {
        var bookId = await _mediator.Send(request, cancellationToken);
        return CreatedAtRoute(nameof(GetBook), new { id = bookId }, bookId);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookCommand updatedBook)
    {
        updatedBook.Id = id;
        await _mediator.Send(updatedBook);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook([FromRoute] DeleteBookCommand request, CancellationToken cancellationToken)
    {   
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}